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
                sh '''
                    dotnet restore ${WEB_API_SOLUTION_FILE} --source https://api.nuget.org/v3/index.json
                    dotnet build ${WEB_API_SOLUTION_FILE} -p:Configuration=release -v:n
                '''
            }
        }
        stage('Test') {
            when {
                expression { params.REQUESTED_ACTION == 'TEST' }
            }
            steps {
                sh'dotnet test ${TEST_PROJECT_PATH}'
            }
        }
    }
}
