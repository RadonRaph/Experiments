void setup() {
 size(1600, 900);
 background(0);
 
 float factorR = random(0.1);
 float factorG = random(0.1);
 float factorB = random(0.1);
 
 
 for (int x =0; x < 1600; x++){
     for (int y =0; y < 900; y++){
       float r = noise(x*factorR, y*factorR)*255;
       float g = noise(x*factorG, y*factorG)*255;
       float b = noise(x*factorB, y*factorB)*255;
       set(x,y,color(r,g,b));
     }
     
 }
 
 

 
  for (int i =0; i<400; i++){
     fill(randomPrimary());
     noStroke();
     circle(random(1600), random(900), random(250));
  }
 
 for (int i =0; i<10; i++){

    filter(BLUR);
 }

 for (int x =200; x < 1600; x+= 200){
   for (int y = 0; y < 900; y++){
     int more = int(sin(y/10)*20);
     //set(x+more, y, color(0,0,0));
     noStroke();
     fill(0);
     circle(x+more, y, 4);
   }
 } 
 
}

color randomPrimary(){
 color ret = color(255,255,255,0); 
  
  int seed = (int)random(3);
  if (seed == 0)
    ret = color(255,255,0,25);
  if (seed == 1)
    ret = color(0,255,255,25);
  if (seed == 2)
    ret = color(255,0,255,25);
  
  
  return ret;
}
