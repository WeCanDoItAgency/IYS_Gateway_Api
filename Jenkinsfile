pipeline {
    agent any
    environment {
        NODE_ENV = 'production'
        REGISTRY = "https://core.harbor.domain:8443"
        DOCKER_REGISTRY_CREDENTIALS = 'harbor_admin_password'
    }
    stages {
        stage('IYS.Gateway.Api') {
            environment {
                IMAGE_TAG = "${env.BUILD_ID}"
                IMAGE_NAME = "core.harbor.domain:8443/dijipol/iysgatewayapi"
                MAIN_DIRECTORY = "kubelet/bots-deployment"
                DOCKERFILE_PATH = "src/IYS.Gateway.Api/Dockerfile"
            }
            steps {
                checkout scm

                script {
                    myapp = docker.build("${IMAGE_NAME}:${IMAGE_TAG}", "-f ${DOCKERFILE_PATH} .")
                }

                script {
                    docker.withRegistry("${REGISTRY}", "${DOCKER_REGISTRY_CREDENTIALS}") {
                        myapp.push("latest")
                        myapp.push("${IMAGE_TAG}")
                    }
                }

                script {
                    def yamlFiles = sh(script: "find ${MAIN_DIRECTORY} -type f -name '*.yaml'", returnStdout: true).trim().split('\n')

                    for (def yamlFile in yamlFiles) {
                        echo "Updating ${yamlFile}"
                        sh "sed -i 's|${IMAGE_NAME}:\${BUILD_ID}|${IMAGE_NAME}:${env.BUILD_ID}|g' ${yamlFile}"
                    }
                }

                script {
                    sh "kubectl --kubeconfig=/root/.kube/newbotconfig apply -f ${MAIN_DIRECTORY}"
                }
            }
        }
    }
}