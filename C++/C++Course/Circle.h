#pragma once
#include "Point.h"
const double PI = 3.14159;
class Circle :public Point {
private:
	double radious;
public:
	Circle(double R, int X, int Y) :Point(X, Y) {
		radious = R;
	}
	double area() {
		return PI * radious * radious;
	}
	void ShowCircle() {
		cout << "Centre of Circle:";
		ShowXY;
		cout << "radious:" << radious << endl;
	}
};