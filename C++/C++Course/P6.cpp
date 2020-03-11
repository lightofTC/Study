#include "Circle.h"
using namespace std;
#include <iostream>

//int P6_1() {
//	Circle Cir1(10, 100, 200);
//	Cir1.ShowCircle();
//	cout << "area is:" << Cir1.area() << endl;
//	Cir1.move(10, 20);
//	Cir1.ShowXY();
//	return 0;
//}
//
//
//
//#include "Point2.h"
//const double PI = 3.14159;
//class Circle :protected Point {
//protected:
//	double radious;
//public:
//	Circle(double R, int X, int Y) :Point(X, Y) {
//		radious = R;
//	}
//	double area() {
//		return PI * radious * radious;
//	}
//	void ShowCircle() {
//		cout << "Centre of Circle:";
//		ShowXY;
//		cout << "radious:" << radious << endl;
//	}
//};
//class Cylinder :protected Circle {
//private:
//	double height;
//public:
//	Cylinder( int X, int Y,double R, double H) :Circle(R,X, Y) {
//		height = H;
//	}
//	double area() {
//		return 2 * Circle::area() + 2 * PI * radious * height;
//	}
//	double volume() {
//		return Circle::area() * height;
//	}
//	void ShowCylinder() {
//		ShowCircle();
//		cout << "height of cylinder:" << height << endl;
//	}
//};
//int P6_2() {
//	Cylinder CY(100, 200, 10, 50);
//	CY.ShowCylinder();
//	cout << "total area:" << CY.area() << endl;
//	cout << "volume:" << CY.volume();
//	return 0;
//}
//
//
//
//


class Point6_3{
private:
	int X, Y;
public:
	Point6_3(int X = 0, int Y = 0) {
		this->X = X, this->Y = Y;
		cout << "Point(" << X << "," << Y << "} constructing..." << endl;
	}
	~Point6_3(){
		cout << "Point(" << X << "," << Y << "} destructing..." << endl;
	}
};
class Circle6_3 :protected Point6_3 {
protected:
	double radius;
public:
	Circle6_3(double R = 0, int X = 0, int Y = 0) :Point6_3(X, Y) {
		radius = R;
		cout << "circle constructing,radius:" << R << endl;
	}
	~Circle6_3() {
		cout << "circle destructing,radius:" << radius << endl;
	}
};
class tube :protected Circle6_3 {
private:
	double height;
	Circle6_3 InCircle;
public:
	tube(double H, double R1, double R2 = 0, int X = 0, int Y = 0):
	InCircle(R2, X, Y), Circle6_3(R1, X, Y) {
		height = H;
		cout << "tube constructing, height :" << H << endl;
	}
	~tube() {
		cout << "tube destructing, height :" << height << endl;
	}
};
int P6_3() {
	tube TU(100, 20, 5);
	return 0;
}



#include "Circle.h"
class Cylinder6_4 :public Circle {
private:
	double height;
public:
	Cylinder6_4(int X, int Y, double R, double H) :Circle(X,Y, R) {
		height = H;
	}
	void ShowCylinder6_4() {
		ShowCircle();
		cout << "height of cylinder:" << height << endl;
	}
};
int P6_4() {
	Point P(1.1);
	Circle Cir(20, 20, 15.5);
	Cylinder6_4 CY(300, 300, 15.5, 50);
	Point * Pp;
	Pp = &P;
	Pp->ShowXY();
	Pp = &CY;
	Pp->ShowXY();
	P = Cir;
	Pp->ShowXY();
	return 0;
}







class Car6_5{
private:
	int power;
	int seat;
public:
	Car6_5(int power, int seat) {
		this->power = power , this->seat = seat;
	}
	void show() {
		cout << "car power:" << power << "    seat" << seat << endl;
	}
};
class Wagon6_5 {
private:
	int power;
	int load;
public:
	Wagon6_5(int power, int load) {
		this->power = power, this->load = load;
	}
	void show() {
		cout << "wagon power;" << power << "   load:" << load << endl;
	}
};
class StationWagon6_5:public Car6_5, public Wagon6_5 {
public:
		StationWagon6_5(int power, int seat, int load):Wagon6_5(power, load),
		Car6_5(power, seat) {
		}
	void ShowSW() {
		cout << "StationWagon:" << endl;
		Car6_5::show();
		Wagon6_5::show();
	}
};
int P6_5() {
	StationWagon6_5 SW(105, 3, 8);
	SW.ShowSW();
	return 0;
}







class Automobile6_6 {
private:
	int power;
public:
	Automobile6_6(int power) {
		this->power = power;
	}
	void show() {
		cout << "  power:" << power;
	}
};
class Car6_6 : public Automobile6_6{
private:
	int seat;     
public:
	Car6_6(int power, int seat) :Automobile6_6(power){
		this->seat = seat;
	}
	void show(){
		cout << "car:";
		Automobile6_6::show();
		cout << "  seat:" << seat << endl;
	}
};
class Wagon6_6 : public Automobile6_6 {
private:
	int load;
public:
	Wagon6_6(int power, int load) :Automobile6_6(power) {
		this->load = load;
	}
	void show6_6() {
		cout << "wagon:";
		Automobile6_6::show();
		cout << "  load:" << load << endl;
	}
};
class StationWagon6_6 :public Car6_6, public Wagon6_6 {
public:
	StationWagon6_6(int CPower, int WPower, int seat, int load)
		:Wagon6_6(WPower, load), Car6_6(CPower, seat) {}
	void show() {
		cout << "StationWagon:" << endl;
		Car6_6::show();
		Wagon6_6::show();
	}
};
int P6_6() {
	StationWagon SW(105, 108, 3, 8);
	SW.show();
	return 0;
}







class Automobile6_7 {
private:
	int power;
public:
	Automobile6_7(int power) {
		this->power = power;
	}
	void show() {
		cout << "   power:" << power;
	}
};
class Car6_7 :public Automobile6_7 {
private:
	int seat;
public:
	Car6_7(int power, int seat) :Automobile6_7(power) {
		this->seat;
	}
	void show() {
		cout << "car:";
		Automobile6_7::show();
		cout << "   seat:" << endl;
	}
};
class Wagon6_7 :virtual public Automobile6_7 {
private:
	int load;
public:
	Wagon6_7(int power,int load):Automobile6_7(power){
		this->load = load;
		cout << "Wagon constructing..." << endl;
	}
	void show() {
		cout << "wagon:" ;
		Automobile6_7::show();
		cout << "   load:" << load << endl;
	}
};
class StationWagon6_7 :public Car6_7, public Wagon6_7 {
public:
	StationWagon6_7(int Cpower, int Wpower, int seat, int load) :Automobile6_7(Cpower),Wagon6_7(Wpower,load),Car6_7(Cpower, seat) {
		cout << "StationWagon constructing..." << endl;
	}
	void show() {
		cout << "StationWagon:" << endl;
		Car6_7::show();
		Wagon6_7::show();
	}
};
int P6_7() {
	StationWagon6_7 SW(105, 108, 3, 8);
	SW.show();
	return 0;
}