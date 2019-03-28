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
     float w = random(250);
     ellipse(random(1600), random(900), w, w);
     
  }
 
 for (int i =0; i<10; i++){

    filter(BLUR);
 }

 for (int x =0; x < 1600; x+= random(100,200)){
   for (int y = 0; y < 900; y++){
     float w = random(3);
     //set(x+more, y, color(0,0,0));
     noStroke();
     fill(0,0,0,100);
     //point(x+sin(y*0.01)*50,y);
     ellipse(x+sin(y*0.01)*50, y, w,w);
   }
 } 
 
 for (int x = 0; x < 1600; x++){
   for (int y = 0; y < 900; y++){
     stroke(randomPrimary());
     //fill(0,0,0,255);
     point(x+sin(y*0.01)*50,y+sin(x*0.01)*50);
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
