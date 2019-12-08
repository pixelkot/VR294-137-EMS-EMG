int data;
unsigned long time_ms;
//Mode 4 => for impulse, other modes start slowly then intensify slowly


void setup() {
  // Setup code runs once.
  Serial.begin(9600);
  // Int+ on pin 13, Int- on pin12.
  pinMode(12, OUTPUT);
  pinMode(13, OUTPUT);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available()) {
    // Data = input to serial monitor.
    data = Serial.read();
    // Delay_button_press = delay in ms between delivering HIGH and LOW (simulate button press)
    int delay_button_press = 70;
    // Delay_between_buttons = delay between button presses.
    int delay_between_buttons = 100;
    // if data is A, deliver
    if(data == 'A') {
      // Keep track of time for debug purposes.
      time_ms = millis();
      Serial.println(time_ms);

      // Awake device.
      Serial.println("Turn Screen On");
      buttonPress(12, delay_button_press);

      // Loop to simulate several button presses
      for (int i = 0; i < 1; i ++) {
        Serial.println(time_ms);
        Serial.println("start");
        buttonPress(12, delay_button_press);
        delay(delay_between_buttons);
        buttonPress(12, delay_button_press);
      }

      // Print total time to increase to set intensity for debug purposes.
      Serial.println(millis()-time_ms);
    } else if (data == 'B') {
      // Keep track of time for debug purposes.
      time_ms = millis();
      Serial.println(time_ms);

      // Awake device.
      Serial.println("Turn Screen On");
      buttonPress(13, delay_button_press);

      // Loop to simulate several button presses
      for (int i = 0; i < 1; i ++) {
        Serial.println(time_ms);
        Serial.println("start");
        buttonPress(13, delay_button_press);
        delay(delay_between_buttons);
        buttonPress(13, delay_button_press);
      }
    }
  }
}

// Function to simulate button press.
void buttonPress(int pinID, int button_delay_ms) {
  digitalWrite(pinID,HIGH);
  delay(button_delay_ms);
  digitalWrite(pinID,LOW);
}
