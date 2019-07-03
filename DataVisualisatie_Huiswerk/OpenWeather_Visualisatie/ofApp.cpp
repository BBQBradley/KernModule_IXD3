#include "ofApp.h"

//--------------------------------------------------------------
void ofApp::setup() 
{
	ofSetCircleResolution(50);
	font.load("HelveticaWorld-Regular.ttf", 40);

	ofSetBackgroundColor(0, 0, 0, 255);

	celciusData = 0;
	getData();
}

//--------------------------------------------------------------
void ofApp::update() {

}

//--------------------------------------------------------------
void ofApp::draw() 
{

	ofSetColor(ofColor::white);
	font.drawString(ofToString(((string)timeOne)), 96, 200);
	font.drawString(ofToString(((string)timeTwo)), 96, 350);
	font.drawString(ofToString(((string)timeThree)), 96, 500);
	font.drawString(ofToString(((string)timeFour)), 96, 650);

	ofSetColor(ofColor::black);
	ofFill();
	ofDrawRectangle(0, 0, 400, 800);
	ofDrawRectangle(538, 0, 400, 800);

	ofSetColor(ofColor::white);
	font.drawString(ofToString(((string)date)), 25, 60);
	font.drawString("Amsterdam", 330, 60);

	// -----------------

	if (circleOne > 20)
	{
		ofSetColor(221, 44, 0);
	}
	else if (circleOne <= 20 && circleOne >= 15)
	{
		ofSetColor(255, 145, 0);
	}
	else if (circleOne <= 15 && circleOne >= 10)
	{
		ofSetColor(85, 139, 47);
	}
	ofFill();
	ofDrawCircle(200, 200, (circleOne * 4));

	ofSetColor(ofColor::black);
	font.drawString(ofToString(((float)circleOne)), 165, 200);

	// -----------------


	if (circleTwo > 20)
	{
		ofSetColor(221, 44, 0);
	}
	else if (circleTwo <= 20 && circleTwo >= 15)
	{
		ofSetColor(255, 145, 0);
	}
	else if (circleTwo <= 15 && circleTwo >= 10)
	{
		ofSetColor(85, 139, 47);
	}
	ofFill();
	ofDrawCircle(200, 350, (circleTwo * 4));

	ofSetColor(ofColor::black);
	font.drawString(ofToString(((float)circleTwo)), 165, 350);

	// -----------------

	if (circleThree > 20)
	{
		ofSetColor(221, 44, 0);
	}
	else if (circleThree <= 20 && circleThree >= 15)
	{
		ofSetColor(255, 145, 0);
	}
	else if (circleThree <= 15 && circleThree >= 10)
	{
		ofSetColor(85, 139, 47);
	}
	ofFill();
	ofDrawCircle(200, 500, (circleThree * 4));

	ofSetColor(ofColor::black);
	font.drawString(ofToString(((float)circleThree)), 165, 500);

	// -----------------

	if (circleFour > 20)
	{
		ofSetColor(221, 44, 0);
	}
	else if (circleFour <= 20 && circleFour >= 15)
	{
		ofSetColor(255, 145, 0);
	}
	else if (circleFour <= 15 && circleFour >= 10)
	{
		ofSetColor(85, 139, 47);
	}
	ofFill();
	ofDrawCircle(200, 650, (circleFour * 4));

	ofSetColor(ofColor::black);
	font.drawString(ofToString(((float)circleFour)), 165, 650);
}

//--------------------------------------------------------------
void ofApp::keyPressed(int key) {

}

//--------------------------------------------------------------
void ofApp::keyReleased(int key) {

}

//--------------------------------------------------------------
void ofApp::mouseMoved(int x, int y) {

}

//--------------------------------------------------------------
void ofApp::mouseDragged(int x, int y, int button) {

}

//--------------------------------------------------------------
void ofApp::mousePressed(int x, int y, int button) {

}

//--------------------------------------------------------------
void ofApp::mouseReleased(int x, int y, int button) {

}

//--------------------------------------------------------------
void ofApp::mouseEntered(int x, int y) {

}

//--------------------------------------------------------------
void ofApp::mouseExited(int x, int y) {

}

//--------------------------------------------------------------
void ofApp::windowResized(int w, int h) {

}

//--------------------------------------------------------------
void ofApp::gotMessage(ofMessage msg) {

}

//--------------------------------------------------------------
void ofApp::dragEvent(ofDragInfo dragInfo) {

}

void ofApp::getData() {
	string url = "https://api.openweathermap.org/data/2.5/forecast?q=Amsterdam,nl&mode=xml&appid=37f584c9d170b496e7abe382b2237a5a&units=metric";
	ofHttpResponse response = ofLoadURL(url); // load data from the API url, store in response object

	if (response.status == 200) { // HTTP code 200 means OK: got a correct response

		if (xml.load(response.data)) { // parse the HTTP response (stored in the data attribute of the response object)
			auto forecastTimeList = xml.find("//weatherdata/forecast/time"); // look up elements by XPATH (see example XML doc)
			ofLog() << forecastTimeList.size() << " elementen gekregen" << endl;

			for (auto& forecastTime : forecastTimeList) { // loop throught the '<time>' elements
				ofXml temperatureElement = forecastTime.getChild("temperature");

				ofLog() << "Datum " << forecastTime.getAttribute("from").getValue()
					<< " : " << temperatureElement.getAttribute("value").getFloatValue()
					<< temperatureElement.getAttribute("unit").getValue() << endl;

				celciusData++;

				cout << forecastTime.getAttribute("from").getValue() << endl;
				cout << temperatureElement.getAttribute("value").getFloatValue();
				cout << celciusData << endl;
				cout << " " << endl;

				if (celciusData == 1)
				{
					circleOne = temperatureElement.getAttribute("value").getIntValue();
					timeAndDate = forecastTime.getAttribute("from").getValue();
					timeOne = forecastTime.getAttribute("from").getValue();

					for (int i = 0; i < 10; i = i + 1){
						chDateArray[i] = timeAndDate.at(i);
						date = chDateArray;
					}
				}
				else if (celciusData == 2)
				{
					circleTwo = temperatureElement.getAttribute("value").getIntValue();
					timeTwo = forecastTime.getAttribute("from").getValue();
				}
				else if (celciusData == 3)
				{
					circleThree = temperatureElement.getAttribute("value").getIntValue();
					timeThree = forecastTime.getAttribute("from").getValue();
				}
				else if (celciusData == 4)
				{
					circleFour = temperatureElement.getAttribute("value").getIntValue();
					timeFour = forecastTime.getAttribute("from").getValue();
				}
			}
		}
		else {
			ofLog() << "Oops. Could not load XML" << endl;
		}
	}
	else {
		ofLog() << "Oops. No data! HTTP code=" << response.status << endl;
	}
}