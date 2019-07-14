#include <iostream>
using namespace std;

class Complex1 {
private:
	double real;
	double image;
public:
	Complex1(double real = 0, double image = 0) {
		this->real = real, this->image = image;
	}
	void display() {
		cout << "(" << real << "," << image << ")" << endl;
	}
	friend Complex1 operator + (Complex1 A, Complex1 B) {
		return Complex1(A.real + B.real, A.image + B.image);
	}
	friend Complex1 operator - (Complex1 A, Complex1 B);
		friend Complex1 operator - (Complex1 A);
		friend Complex1 operator ++ (Complex1 &A);
		friend Complex1 operator ++ (Complex1 &A, int);
};
Complex1 operator - (Complex1 A, Complex1 B) {
	return Complex1(A.real - B.real, A.image - B.image);
}
Complex1 operator - (Complex1 A) {
	return Complex1(-A.real, -A.image);
}
Complex1 operator ++ (Complex1 &A) {
	return Complex1(++A.real, ++A.image);
}
Complex1 operator ++ (Complex1 &A, int) {
	return Complex1(A.real++,A.image);
}
int P7_1() {
	Complex1 A(100.0, 200.0), B(-10.0, 20.0), C;
	cout << "A=",       A.display();
	cout << "B=",        B.display();
	C = A + B;
	cout << "C = A + B=", C.display();
	C = A - B;
	cout << "C = A - B=", C.display();
	C = -A + B;
	cout << "C = -A + B=", C.display();
	C = A++;
	cout << "C = A ++, C=", C.display();
	C = ++A;
	cout << "C = ++A, C=", C.display();
	C = A + 5;
	C.display();
	return 0;
}









class Complex2 {
private:
	double real;
	double image;
public:
	Complex2(double real = 0, double image = 0) {
		this->real = real, this->image = image;
	}
	void display() {
		cout << "(" << real << "," << image << ")" << endl;
	}
	Complex2 operator + (Complex2 B);
	Complex2 operator - (Complex2 B);
	Complex2 operator - ();
	Complex2 operator ++ ();
	Complex2 operator ++ (int);
};
Complex2 Complex2::operator + (Complex2 B) {
	return Complex2(real + B.real, image + B.image);
}
Complex2 Complex2::operator - (Complex2 B) {
	return Complex2(real - B.real, image - B.image);
}
Complex2 Complex2::operator - () {
	return Complex2(-real, -image);
}
Complex2 Complex2::operator ++ () {
	return Complex2(++real, image );
}
Complex2 Complex2::operator ++ (int) {
	return Complex2(real++, image);
}
int P7_2() {
	Complex2 A(100.0, 200.0), B(-10.0, 20.0), C;
	cout << "A=", A.display();
	cout << "B=", B.display();
	C = A + B;
	cout << "C = A + B=", C.display();
	C = A - B;
	cout << "C = A - B=", C.display();
	C = -A + B;
	cout << "C = -A + B=", C.display();
	C = A++;
	cout << "C = A ++, C=", C.display();
	C = ++A;
	cout << "C = ++A, C=", C.display();
	C = A + 5;
	C.display();
	return 0;
}









class Complex3 {
private:
	double real;
	double image;
public:
	Complex3(double real = 0.0, double image = 0.0) {
		this->real = real, this->image = image;
	}
	void display() {
		cout << "(" << real << "," << image << ")" << endl;
	}
	Complex3 operator + (Complex3 B);
	Complex3 operator = (Complex3 B);
};
Complex3 Complex3::operator + (Complex3 B) {
	return Complex3(real + B.real, image + B.image);
}
Complex3 Complex3::operator = (Complex3 B) {
	real = B.real, image = B.image;
	cout << "operator = calling..." << endl;
	return *this;
}
int P7_3() {
	Complex3 A(100.0, 200.0), B(-10.0, 20.0), C;
	cout << "A=", A.display();
	cout << "B=", B.display();
	C = A + B;
	cout << "C = A + B=", C.display();
	C = A;
	cout << "C = A = ", C.display();
	return 0;
}




class Complex4 {
private:
	double real;
	double image;
public:
	Complex4(double real = 0.0, double image = 0.0) {
		this->real = real, this->image = image;
	}
	void display() {
		cout << "(" << real << "," << image << ")" << endl;
	}
};
class PComplex {
private:
	Complex4 * PC;
public:
	PComplex(Complex4 * PC = NULL) {
		this->PC = PC;
	}
	Complex4 * operator ->() {
		static Complex4 NullComplex(0.0);
		if (PC == NULL) {
			return &NullComplex;
		}
		return PC;
	}
};
int P7_4() {
	PComplex P1;
	P1->display();
	Complex4 C1(100, 200);
	P1 = &C1;
	P1->display();
	return 0;
}







class String7_5 {
private:
	char *Str;
	int len;
public:
	void ShowStr() {
		cout << "string:" << Str << ",length:" << len << endl;
	}
	String7_5(const char *p = NULL) {
		if (p) {
			len = strlen(p);
			Str = new char[len + 1];
			strcpy(Str, p);
		}
		else {
			len = 0;
			Str = NULL;
		}
	}
	~String7_5() {
		if (Str != NULL)
			delete[] Str;
	}
	char &operator[](int n) {
		return *(Str + n);
	}
	const char &operator[](int n)const {

		return *(Str + n);
	}
};
int P7_5(void)
{   
    String7_5 S1("0123456789abcdef");
    S1.ShowStr();
    S1[10]='A';
    cout<<" after S1[10]=A"<<endl;
    S1.ShowStr();
    const String7_5 S2("ABCDEFGHIJKLMN");
    cout<<"S2[10]="<<S2[10]<<endl;
    return 0;
}




class Point7_6 {
private:
	int X, Y;
public:
	Point7_6(int X = 0, int Y = 0)
	{
		this->X = X, this->Y = Y;
	}
	double area()
	{
		return 0.0;
	}
};
const double PI = 3.14159;
class Circle :public Point7_6 {
private:
	double radius;
public:
	Circle(int X, int Y, double R) :Point7_6(X, Y) {
		radius = R;
	}
	double area() {
		return PI * radius*radius;
	}
};
int P7_6() {
	Point7_6 P1(10, 10);
	cout << "P1.area()=" << P1.area() << endl;
	Circle C1(10, 10, 20);
	cout << "C1.area()=" << C1.area() << endl;
	Point7_6 *Pp;
	Pp = &C1;
	cout << "Pp->area()=" << Pp->area() << endl;
	Point7_6& Rp = C1;
	cout << "Rp.area()=" << Rp.area() << endl;
	return 0;
}





class Point7_7 {
private:
	int X, Y;
public:
	Point7_7(int X = 0, int Y = 0) {
		this->X = X, this->Y = Y;
	}
	virtual double area() {
		return 0.0;
	}
};
const double PI = 3.14159;
class Circle :public Point7_7 {
private:
	double radius;
public:
	Circle(int X, int Y, double R) :Point7_7(X, Y) {
		radius = R;
	}
	double area() {
		return PI * radius*radius;
	}
};
int P7_7() {
	Point7_7 P1(10, 10);
	cout << "P1.area()=" << P1.area() << endl;
	Circle C1(10, 10, 20);
	cout << "C1.area()=" << C1.area() << endl;
	Point7_7 *Pp;
	Pp = &C1;
	cout << "Pp->area()=" << Pp->area() << endl;
	Point7_7 & Rp = C1;
	cout << "Rp.area()=" << Rp.area() << endl;
	return 0;
}







class A7_8 {
public:
	virtual ~A7_8() {
		cout << "A::~A() is called." << endl;
	}
	A7_8() {
		cout << "A::A() is called." << endl;
	}
};
class B7_8 : public A7_8 {
private:
	int  *ip;
public:
	B7_8(int size = 0) {
		ip = new int[size];
		cout << "B::B() is called." << endl;
	}
	~B7_8() {
		cout << "B::~B() is called." << endl;
		delete[]  ip;
	}
};
int P7_8() {
	A7_8 *b = new B7_8(10);
	delete b;
	return 0;
}





class Shape7_9 {
public:
	virtual double area()const = 0;
	virtual void   show() = 0;
};
class Point7_9 :public Shape7_9 {
public:
   virtual double area()const=0;
   virtual void   show()=0; 
};
class Point7_9 :public Shape7_9 {
protected:
        int X,Y;
public:
        Point7_9(int X=0,int Y=0) {
            this->X=X,this->Y=Y;  
       }
        void show() {	
            cout<<"("<<X<<","<<Y<<")"<<endl;	
       }
        double area() const {
            return 0.0; 
    }
};
const double PI=3.14159;
class Circle7_9 :public Point7_9 {
protected:
	double radius;
public:
	Circle7_9(int X, int Y, double R) :Point7_9(X, Y) {
		radius = R;
	}
	double area7_9() const {
		return PI * radius*radius;
	}
	void show7_9() {
		cout << "(" << X << "," << Y << ")" << endl;
	}
	double area7_9() const {
		return 0.0;
	}
};
const double PI = 3.14159;
class Circle7_9 :public Point7_9 {
protected:
	double radius;
public:
	Circle7_9(int X, int Y, double R) :Point7_9(X, Y) {
		radius = R;
	}
	double area7_9() const {
		return PI * radius*radius;
	}
	void show7_9() {
		cout << "Centre:" << "(" << X << "," << Y << ")" << endl;
		cout << "radius:" << radius << endl;
	}
};
class Cylinder7_9 : public Circle7_9 {
private:
	double height;
public:
	Cylinder7_9(int X, int Y, double R, double H) :Circle7_9(X, Y, R) {
		height = H;
	}
	double area7_9() const {
		return 2 * Circle7_9::area7_9() + 2 * PI*radius*height;
	}
	void show7_9()
	{
		Circle7_9::show7_9();
		cout << "height of cylinder:" << height << endl;
	}
};
int P7_9()
{
	Cylinder7_9 CY(100, 200, 10, 50);
	Shape7_9 * P;
	P = &CY;
	P->show();
	cout << "total area:" << P->area() << endl;
	Circle7_9 Cir(5, 10, 100);
	Shape7_9 &R = Cir;
	R.show();
	return 0;
}
