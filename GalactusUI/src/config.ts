export class Config{
    consequenceEndpointBaseUrl: string = "http://consequence-clusterip-srv:80/consequence";
    moodEndpointBaseUrl: string = "http://mood-clusterip-srv:80/mood";
    // reactionEndpointBaseUrl: string = "http://reaction-clusterip-srv:80/reaction";
    
    reactionEndpointBaseUrl: string = "http://localhost:30604/reaction"; //this changes with every k8s deployment
}
