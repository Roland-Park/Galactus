# Galactus
Microservices-based app using Kubernetes and Istio. For learning purposes only.

List of Microservices:
- ReactionService: reacts when you hit it
- ConsequenceService: your actions towards ReactionService will have consequences.
- MoodService: Defines and provides the moods the bots can be in. 
- UI: The UI

Stack
.net6/EF
angular

To run:
This assumes you have k8s enabled in docker desktop, or something similar to run a k8s node.

1. build the docker images (Replace my name with your docker repo name, or dont).
- From the Galactus directory, run: 
  - `docker build -t rolandpark/consequenceservice -f ConsequenceServiceApi/Dockerfile .` 
  - `docker build -t rolandpark/reactionservice -f ReactionsServiceApi/Dockerfile .`
  - `docker build -t rolandpark/moodservice -f MoodServiceApi/Dockerfile .`
- From the GalactusUI directory, run:
  - `docker build -t rolandpark/galactusui .` (optional, since for now I'm running the ui locally)

2. Push the images to your docker repository:
- `docker push rolandpark/reactionservice`
- `docker push rolandpark/consequenceservice`
- `docker push rolandpark/moodservice`
- `docker push rolandpark/galactusui` (optional, since for now I'm running the ui locally)

3. Deploy to k8s - update the api depl.yaml 'images' section with the names of the image you pushed to dockerhub in step 2. Then from within the Kubernetes directory, run: 
- `kubectl apply -f consequence-depl.yaml` create consequence service
- `kubectl apply -f reaction-depl.yaml` create reaction service
- `kubectl apply -f mood-depl.yaml` create mood service
- `kubectl apply -f rabbitmq-depl.yaml` create message bus. RabbitMQ ui available on localhost:15672
- `kubectl apply -f platforms-nodeport-service.yaml` ingress for reactionservice. Get the port by running `kubectl get services`
- `kubectl apply -f ui-depl.yaml` create ui (optional, since for now I'm running the ui locally)

4. In GalactusUI, update config.ts  with the NodePort port from step 3, then run:
- `npm install`
- `npm start`

TODO
- figure out why I get a cors error when running the angular ui in the cluster
- get istio working with an api gateway (may fix cors error?)
- explore istio features
- profit
- retire
