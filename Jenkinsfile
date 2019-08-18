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
    }
    stages {
        stage('Build') {
            when {
                expression { params.REQUESTED_ACTION == 'BUILD' || params.REQUESTED_ACTION == 'TEST' }
            }
            steps {
                bat '''
              
                echo "----------------------------Build-----------------------------"
                dotnet build %SOLUTION_FILE_PATH% -p:Configuration=release -v:n
               
                echo "----------------------------Test-----------------------------"
                dotnet test %TEST_FILE_PATH%
               
                echo "----------------------------Publishing-----------------------------"
                dotnet publish %SOLUTION_FILE_PATH% -c Release -o ../publish
               
                '''
            }
        }
        stage('Test') {
            when {
                expression { params.REQUESTED_ACTION == 'TEST' }
            }
            steps {
                
            }
        }
    }
}
