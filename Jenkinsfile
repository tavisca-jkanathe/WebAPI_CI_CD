pipeline {
    agent any
    parameters {
        choice(
            choices: ['BUILD' , 'TEST'],
            description: '',
            name: 'REQUESTED_ACTION')
        string(
              name: 'GIT_URL',
              defaultValue: 'https://github.com/tavisca-jkanathe/WebAPI.git',
              description: 'repository path')
        string(
               name: 'WEB_API_SOLUTION_FILE',
               defaultValue: 'WebAPI.sln',
               description: 'solution path')
        string(
             name: 'TEST_PROJECT_PATH',
             defaultValue: 'XUnitWebAPITest/XUnitWebAPITest.csproj',
             description: 'test path')
        string(
            name: 'DOCKER_USERNAME', 
            defaultValue: 'jayantvnk',
             description: 'docker username')
        string(
            name: 'DOCKER_PASSWORD',
            defaultValue:'jayantadmin',
            description: 'docker password')
        string(
            name: 'DOCKER_REPO_NAME',
            defaultValue:'jayantvnk/webapi',
            description: 'docker repository')
        string(
            name: 'IMAGE_VERSION',
            defaultValue:'latest',
            description: 'docker image version')
        string(
            name: 'SOLUTION_NAME', 
            defaultValue: 'WebApi',
            description: 'solution name')
    }
    stages {
        stage('Build') {
            when {
                expression { params.REQUESTED_ACTION == 'BUILD' || params.REQUESTED_ACTION == 'TEST' }
            }
            steps {
                bat '''
              
                echo "----------------------------Build-----------------------------"
                dotnet build %WEB_API_SOLUTION_FILE% -p:Configuration=release -v:n
               
                echo "----------------------------Test-----------------------------"
                dotnet test %TEST_PROJECT_PATH%
               
                echo "----------------------------Publishing-----------------------------"
                dotnet publish %WEB_API_SOLUTION_FILE% -c Release -o ../publish
                
                echo "----------------------------make artifact-----------------------------"
                compress-archive WebApi/bin/Release/netcoreapp2.1/publish/ artifact.zip -Update
                
                  echo "----------------------------DockeImage-----------------------------"
                docker build -t %DOCKER_REPO_NAME%:%IMAGE_VERSION% --build-arg project_name=%SOLUTION_NAME%.dll .
               
                '''
            }
        }
         stage('Deploy') {
            steps {
                bat '''
                echo "----------------------------Deploy-----------------------------"
                docker login -u %DOCKER_USERNAME% -p %DOCKER_PASSWORD%
                docker push %DOCKER_REPO_NAME%:%IMAGE_VERSION%
                
                expand-archive ..jkanathe_webapi_build_deploy/artifact.zip ./ -Force
                    dotnet publish/WebApi.dll
                '''
            }
        }
        
    }
}
