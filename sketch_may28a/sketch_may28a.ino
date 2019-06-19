char myCol[6];
char lf = 'S';
int CheckStrCon(char* a, char* b);
void setup() {
  // put your setup code here, to run once:
  Serial.begin(19200);
  pinMode(3,OUTPUT);
  pinMode(5,OUTPUT);
  pinMode(6,OUTPUT);
  pinMode(9,OUTPUT);
  pinMode(10,OUTPUT);
  pinMode(LED_BUILTIN, OUTPUT);
  //pinMode(5,OUTPUT);
  analogWrite(3, 0);
  analogWrite(5, 0);
  analogWrite(6, 0);
  analogWrite(9, 0);
  analogWrite(10, 0);
  analogWrite(LED_BUILTIN, LOW); 
}

void loop() {
  // put your main code here, to run repeatedly:
  delay(5);
  analogWrite(3, 0);
  analogWrite(5, 0);
  analogWrite(6, 0);
  analogWrite(9, 0);
  analogWrite(10, 0);
  //digitalWrite(LED_BUILTIN, LOW);
  if(Serial.available() > 0){
    while (Serial.peek() == 'S')
    {
      Serial.readBytes(myCol,6);
      if(CheckStrCon(myCol,'i')){
        Serial.println("index");
        analogWrite(5, 100);
      }
      if(CheckStrCon(myCol,'I')){
        Serial.println("index");
        analogWrite(5, 255);
      }
       if(CheckStrCon(myCol,'b')){
        Serial.println("index");
        analogWrite(5, 55);
      }      
      if(CheckStrCon(myCol,'m')){
        Serial.println("middle");
        analogWrite(6, 100);
      }
      if(CheckStrCon(myCol,'M')){
        Serial.println("middle");
        analogWrite(6, 255);
      }  
       if(CheckStrCon(myCol,'c')){
        Serial.println("middle");
        analogWrite(6, 55);
      }             
      if(CheckStrCon(myCol,'r')){
        Serial.println("ring");
        analogWrite(9, 100);
      }
      if(CheckStrCon(myCol,'R')){
        Serial.println("ring");
        analogWrite(9, 255);
      }
       if(CheckStrCon(myCol,'d')){
        Serial.println("ring");
        analogWrite(9, 55);
      }   
      if(CheckStrCon(myCol,'l')){
        Serial.println("little");
        analogWrite(10, 100);
      }
       if(CheckStrCon(myCol,'L')){
        Serial.println("little");
        analogWrite(10, 255);
      }
       if(CheckStrCon(myCol,'e')){
        Serial.println("little");
        analogWrite(10, 55);
      }
    }


    while(Serial.available()>0)
    {
      Serial.read();
    }
  }
}

int CheckStrCon(char* a, char* b){
  if((a[1]== b)||(a[2]== b)||(a[3]== b)||(a[4]== b)||(a[5]== b)){
    return 1;      
  }
  return 0;
}
