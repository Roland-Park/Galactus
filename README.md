# Galactus
Microservice app using Kubernetes and Istio

List of Microservices:
- ReactionService: reacts when you hit it
- ConsequenceService: your actions towards ReactionService will have consequences.
- MoodService: Defines and provides the moods the bots can be in. 
- UI: The UI

##Stack
.net6/EF
angular

To run:
This assumes you have k8s enabled in docker desktop, or something similar to run a k8s node.
1. build the docker images for the two apis. From the Galactus directory, run: 
- `docker build -t <your repo name>/consequenceservice -f ConsequenceServiceApi/Dockerfile .` 
- `docker build -t <your repo name>/reactionservice -f ReactionsServiceApi/Dockerfile .`
- `docker build -t <your repo name>/moodservice -f MoodServiceApi/Dockerfile .`

2. push the images to a docker repository.
- `docker push <your repo name>/reactionservice`
- `docker push <your repo name>/consequenceservice`
- `docker push <your repo name>/moodservice`

3. Deploy to k8s. Update the images section of the api depl.yaml files with the name of the image you pushed to dockerhub in step 2. From within the Kubernetes directory, run: 
- `kubectl apply -f consequence-depl.yaml` create consequence service
- `kubectl apply -f reaction-depl.yaml` create reaction service
- `kubectl apply -f mood-depl.yaml` create mood service
- `kubectl apply -f platforms-nodeport-service.yaml` maps the reaction service to a port (just to verify k8s works), eg http://localhost:31590/reaction. You can get the port by running `kubectl get services`


