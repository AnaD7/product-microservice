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
   	stage('Preparation') {
         steps {
            cleanWs()
	    checkout scm
	}
      }
	   
  	stage('Build') {
         steps {
            sh '''echo No build required for Product microservice'''
         }
      }
	   
      stage('Test') {
         steps {
            sh 'dotnet test ProductMicroservice.sln'
	 }
      }
      
      stage('Build and Push Image') {
         steps {
           sh 'docker image build -t ${REPOSITORY_TAG} .'
         }
      }

      stage('Deploy to Cluster') {
          steps {
            sh 'envsubst < ${WORKSPACE}/deploy.yaml | kubectl apply -f -'
          }
      }
   }
}
