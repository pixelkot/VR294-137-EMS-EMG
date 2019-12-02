int data;
unsigned long time_ms;
//Mode 4 => for impulse, other modes start slowly then intensify slowly


void setup() {
  // Setup code runs once.
  Serial.begin(9600);
  // LED on pin 8.
  pinMode(8, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available()) {
    // Data = input to serial monitor.
    data = Serial.read();
    // Delay_button_press = delay in ms between delivering HIGH and LOW (simulate button press)
    int delay_button_press = 60;
    // Delay_between_buttons = delay between button presses.
    int delay_between_buttons = 60;
    // if data is A, deliver 
    if(data == 'A') {
      // Keep track of time for debug purposes.
      time_ms = millis();
      Serial.println(time_ms);

      // Awake device.
      Serial.println("Turn Screen On");
      buttonPress(delay_button_press);

      // Loop to simulate several button presses
      for (int i = 0; i < 4; i ++) {
        Serial.println(time_ms);
        Serial.println("start");
        buttonPress(delay_button_press);
        delay(delay_between_buttons);
        buttonPress(delay_button_press);
      }

      // Print total time to increase to set intensity for debug purposes. 
      Serial.println(millis()-time_ms);
    } 
  }
}

// Function to simulate button press.
void buttonPress(int button_delay_ms) {
  digitalWrite(8,HIGH);
  delay(button_delay_ms);
  digitalWrite(8,LOW);
}
