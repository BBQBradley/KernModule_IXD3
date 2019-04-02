#pragma once

#include "ofMain.h"
#include "ofxSQLiteCpp.h"

class ofApp : public ofBaseApp {

public:
	void setup();
	void update();
	void draw();

	void keyPressed(int key);
	void mouseMoved(int x, int y);

private:
	ofTrueTypeFont font;

	int yearIndex = 0;

	int years[5] = { 1995, 2000, 2005, 2010, 2015 };

	float lerpYear;
	float popAULerpValue;
	float popNLLerpValue;
	float popZHLerpValue;

	SQLite::Database* db;
};