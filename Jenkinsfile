pipeline {
    agent any

    environment {
        DOCKER_REGISTRY = 'https://index.docker.io/v1/'
        DOCKER_REPO = 'tranbinhminh2110/se162152productmanagement'
    }

    stages {
        stage('Checkout') {
            steps {
                echo 'Checking out source code...'
                checkout scm
            }
        }

        stage('Restore') {
            steps {
                echo 'Restoring .NET dependencies...'
                catchError(buildResult: 'FAILURE') {
                    bat 'dotnet restore'
                }
            }
        }

        stage('Build') {
            steps {
                echo 'Building the .NET application...'
                catchError(buildResult: 'FAILURE') {
                    bat 'dotnet build --configuration Release'
                }
            }
        }

        stage('Test') {
            steps {
                echo 'Running tests...'
                catchError(buildResult: 'FAILURE') {
                    bat 'dotnet test'
                }
            }
        }

        stage('Publish') {
            steps {
                echo 'Publishing the application...'
                catchError(buildResult: 'FAILURE') {
                    bat 'dotnet publish --configuration Release --output ./publish'
                }
            }
        }

        stage('Build and Push Docker Image') {
            steps {
                script {
                    catchError(buildResult: 'FAILURE') {
                        docker.withRegistry(DOCKER_REGISTRY, 'demo-docker') {
                            bat "docker build -t ${DOCKER_REPO} ."
                            bat "docker push ${DOCKER_REPO}"
                        }
                    }
                }
            }
        }
    }
}
