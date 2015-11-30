//Using Ditial Switch

int inputPin = 7;
int outputPin = 13;
int input = 0;

void setup() {
	pinMode(outputPin, OUTPUT);
	pinMode(inputPin, INPUT);
}

void loop() {

	input = digitalRead(inputPin);
	if (input == 1) {
		digitalWrite(outputPin, HIGH);
	}
	else if (input == 0) {
		digitalWrite(outputPin, LOW);
	}

	delay(500);
}
