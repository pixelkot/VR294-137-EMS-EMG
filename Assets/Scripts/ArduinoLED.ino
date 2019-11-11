int data;

void setup() {
  // put your setup code here, to run once:
  Serial.begin(9600);
  // LED on 13
  pinMode(13, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available()) {
    data = Serial.read();
    // if data is A, turn on LED
    if(data == 'A') {
      digitalWrite(13,HIGH);
    } else {
      digitalWrite(13,LOW);
    }
  }
}
