#include "ofApp.h"

void ofApp::setup() {
	ofSetCircleResolution(50);
	font.load("HelveticaWorld-Regular.ttf", 64);

	try {
		string databasePath = ofToDataPath("Huishoudens.db", true);
		db = new SQLite::Database(databasePath);
	}
	catch (const std::exception& e) {
		ofLogError() << e.what() << endl;
	}
}

void ofApp::update() {
}

void ofApp::draw() 
{
	
	try {
		SQLite::Statement query(*db, "SELECT * FROM huishoudens WHERE year=?");

		int year = years[yearIndex];
		ofLog() << "year = " << year << endl;
		query.bind(1, year);

		while (query.executeStep()) {
			//        ofLog() << query.getColumn("year") << " "
			//                << query.getColumn("nl")
			//                << endl;
			popNLLerpValue = ofLerp(popNLLerpValue, query.getColumn("field3").getInt(), 0.05);
			ofSetColor(ofColor::slateBlue);
			ofDrawRectangle(100, 700, 100, popNLLerpValue / -8000);

			popAULerpValue = ofLerp(popAULerpValue, query.getColumn("field4").getInt(), 0.05);
			ofSetColor(ofColor::cornflowerBlue);
			ofDrawRectangle(300, 700,  100, popAULerpValue / -8000);

			popZHLerpValue = ofLerp(popZHLerpValue, query.getColumn("field5").getInt(), 0.05);
			ofSetColor(ofColor::blue);
			ofDrawRectangle(500, 700, 100, popZHLerpValue / -8000);

			// het jaar interpoleren we in stappen van 10% (0.1)
			lerpYear = ofLerp(lerpYear, years[yearIndex], 0.5);
			ofSetColor(ofColor::white);
			font.drawString(ofToString(((int)lerpYear)), 700, 500);
		}
	}
	catch (const std::exception& e) {
		ofLogError() << e.what() << endl;
	}
	
}

void ofApp::keyPressed(int key) {
}

void ofApp::mouseMoved(int x, int y) {
	yearIndex = ofMap(x, 0, ofGetWidth(), 0, 5);
}