# Galactus
Microservice app using Kubernetes and Istio

List of Microservices:
- ReactionService: reacts when you hit it
- ConsequenceService: your actions towards ReactionService will have consequences.
- MoodService: I got lazy and added this as an endpoint to the ConsequenceService.
- UI: The UI

##Stack
.net6/EF
angular

To run:
This assumes you have k8s enabled in docker desktop, or something similar to run a k8s node.
1. build the docker images for the two apis. From the Galactus directory, run: 
- `docker build -t <your repo name>/consequenceservice -f ConsequenceServiceApi/Dockerfile .` 
- `docker build -t <your repo name>/reactionservice -f ReactionsServiceApi/Dockerfile .`

2. push the images to a docker repository.
- `docker push <your repo name>/reactionservice`
- `docker push <your repo name>/consequenceservice`

3. Deploy to k8s. Update the images section of the depl.yaml files with the name of the image you pushed to dockerhub in step 2. From within the Kubernetes directory, run: 
- `kubectl apply -f consequence-depl.yaml` 
- `kubectl apply -f reaction-depl.yaml` 

