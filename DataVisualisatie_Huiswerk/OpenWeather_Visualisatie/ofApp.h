#pragma once

#include "ofMain.h"

class ofApp : public ofBaseApp {

public:
	void setup();
	void update();
	void draw();

	void keyPressed(int key);
	void keyReleased(int key);
	void mouseMoved(int x, int y);
	void mouseDragged(int x, int y, int button);
	void mousePressed(int x, int y, int button);
	void mouseReleased(int x, int y, int button);
	void mouseEntered(int x, int y);
	void mouseExited(int x, int y);
	void windowResized(int w, int h);
	void dragEvent(ofDragInfo dragInfo);
	void gotMessage(ofMessage msg);

	void getData();

private:
	ofXml xml;
	ofTrueTypeFont font;

	int celciusData = 0;

	int length;

	char chDateArray[9];

	char chTimeArray[19];

	string timeAndDate = " ";
	string timeAndDate2 = " ";
	string date = " ";

	string timeOne = " ";	
	string timeTwo = " ";
	string timeThree = " ";
	string timeFour = " ";

	float circleOne = 0;
	float circleTwo = 0;
	float circleThree = 0;
	float circleFour = 0;

};