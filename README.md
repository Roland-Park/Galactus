# Galactus
Microservices-based app using Kubernetes and Istio. For learning purposes only.

List of Microservices:
- ReactionService: reacts when you hit it
- ConsequenceService: your actions towards ReactionService will have consequences.
- MoodService: Defines and provides the moods the bots can be in. 
- UI: The UI

### Stack
dotnet6/EF
angular

To run:
This assumes you have k8s enabled in docker desktop, or something similar to run a k8s node.

## Step 1
Build the docker images (Replace my name with your docker repo name, or dont).
- From the Galactus directory, run: 
  - `docker build -t rolandpark/consequenceservice -f ConsequenceServiceApi/Dockerfile .` 
  - `docker build -t rolandpark/reactionservice -f ReactionsServiceApi/Dockerfile .`
  - `docker build -t rolandpark/moodservice -f MoodServiceApi/Dockerfile .`
- From the GalactusUI directory, run:
  - `docker build -t rolandpark/galactusui .` (optional, since for now I'm running the ui locally)

## Step 2
Push the images to your docker repository:
- `docker push rolandpark/reactionservice`
- `docker push rolandpark/consequenceservice`
- `docker push rolandpark/moodservice`
- `docker push rolandpark/galactusui` (optional, since for now I'm running the ui locally)

## Step 3
Set up Istio control plane
- add Galactus/Istio/istio-1.13.2/bin to your system environment variable. This will enable the istioctl command line functions.
- run `istioctl install --set profile=demo -y`
- run `kubectl label namespace default istio-injection=enabled` to add the "istio-injection=enabled" label to the default namespace. Now, any deployment added to this namespace will get an istio sidecar.
- I used https://istio.io/latest/docs/setup/getting-started/ as reference. More details can be found there

## Step 3a
Api Gateway
- set up istio ingress: TODO
- for now, we can access the reactionService via the nodeport

## Step 4
Deploy to k8s. Update the api depl.yaml 'images' section with the names of the image you pushed to dockerhub in step 2. Then from within the Galactus directory, run: 
- `kubectl apply -f kubernetes` runs all deployments in the Galactus/Kubernetes directory
- running `kubectl get pods` should show 2 containers per pod.

## Step 5
(optional) In GalactusUI, update config.ts  with the NodePort port from step 3, then run the app (outside the cluster for now):
- `npm install`
- `npm start`

## Step 6
Testing
- localhost:15672 is the queue ui
- run `istioctl dashboard kiali` to start the kiali dashboard
- run `kubectl get services` to get the nodeport port. localhost:<port>/reaction will hit the reaction service, which loads moods from moodservice via http and then writes the reactionbot's mood to the queue.

## TODO
- figure out why I get a cors error when running the angular ui in the cluster
- figure out why appsettings arent picked up properly in consequenceService
- figure out istio gateway setup and get it working (may fix angular cors error?)
- explore istio features
- profit
- retire
