//Blink LED Using Serial Input

int PIN_NO = 8;

void setup() {
	pinMode(PIN_NO, OUTPUT);
	Serial.begin(19200);
	Serial.println("Enter 1 for Turning LED on and 0 for Turning it OFF");
}

void loop() {

	if (Serial.available()) {
		int n = Serial.read();
		n = n - 48;

		if (n == 1) {
			digitalWrite(PIN_NO, HIGH);
			Serial.println("LED is ON");
		}
		else if (n == 0) {
			digitalWrite(PIN_NO, LOW);
			Serial.println("LED is OFF");
		}
		else {
			Serial.println("Only 0 or 1 is allowed as input");
		}
	}
}
