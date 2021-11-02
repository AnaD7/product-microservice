pipeline {
   agent any

   environment {
     // Environment variables which need to be set in Jenkins
     // ORGANIZATION_NAME = "AnaD7"
     // YOUR_DOCKERHUB_USERNAME = "anadrvoshanova"

     SERVICE_NAME = "product-microservice"
     REPOSITORY_TAG="${YOUR_DOCKERHUB_USERNAME}/${SERVICE_NAME}:${BUILD_ID}"
   }

   stages {
      stage('Build') {
         steps {
            sh '''echo No build required for Queue'''
         }
      }

      stage('Build and Push Image') {
         steps {
           sh 'docker image build -t ${REPOSITORY_TAG}/DevOpsMicroservices/Dockerfile .'
         }
      }

      stage('Deploy to Cluster') {
          steps {
            sh 'envsubst < ${WORKSPACE}/deploy.yaml | kubectl apply -f -'
          }
      }
   }
}
