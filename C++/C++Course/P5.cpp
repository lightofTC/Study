using namespace std;
#include<iostream>
#define _CRT_SECURE_NO_WARNINGS;


struct Clock {
	int H, M, S;
};

Clock MyClock;

void SetTime(int H, int M, int S){
	MyClock.H = (H >= 0 && H<24) ? H : 0;
    MyClock.M = (M >= 0 && M<60) ? M : 0;
    MyClock.S = (S >= 0 && S<60) ? S : 0;
}
void ShowTime() {
	cout << MyClock.H << ":"; 
    cout << MyClock.M << ":";
	cout << MyClock.S << ":";
}
int P5_1_a()
{
	ShowTime();
	SetTime(8, 30, 30);
    ShowTime();
return 0;
}







class Clock1 
{
 private:
	  int H, M, S;
public:
	void SetTime(int h, int m, int s)
	{
		H = (h >= 0 && h < 24) ? h : 0;
		M = (m >= 0 && m < 24) ? m : 0;
		S = (s >= 0 && s < 24) ? s : 0;
	}  
	void ShowTime()
	{
		cout << H << ":" << M << ":" << S << endl;
	}
	
};
int P5_1_b() {
	Clock1 MyClock;
	MyClock.ShowTime();
	MyClock.SetTime(8, 30, 30);
	MyClock.ShowTime();
	return 0;
}





class Clock2 {
private:
	int H, M, S;
public:
	Clock2(int h = 0, int m = 0, int s = 0) {
		H = h, M = m, S = s;
		cout << "constructor:" << H << ":" << M << ":" << S << endl;
	}
	~Clock2() {
		cout << "destructor:" << H << ":" << M << ":" << S << endl;
	}
};
int P5_2() {
	Clock2 C3(10, 0, 0);
	Clock2 C4(11, 0, 0);
	return 0;
}
Clock2 C1(8, 0, 0);
Clock2 C2(9, 0, 0);



class String3 {
private:
	char * Str;
	int len;
public:
	void ShowStr() {
		cout << "String:" << Str << ",length:" << len << endl;
	}
	String3() {
		len = 0;
		Str = NULL;
	}
	String3(const char *p) {
		len = strlen(p);
		Str = new char[len + 1];
		strcpy(Str, p);
	}
	~String3()
	{
		if (Str != NULL) {
			delete[]Str;
			Str = NULL;
		}
	}
};

int P5_3(){
	char s[] = "ABCDE";
	String3 s1(s);
	String3 s2("123456");
	s1.ShowStr();
	s2.ShowStr();
	return 0;
	}




class Clock4 {
private:
	int H, M, S;
public:
	Clock4(int h = 0, int m = 0, int s = 0) {
		H = h, M = m, S = s;
		cout << "constructor:" << H << ":" << M << ":" << S << endl;
	}
	~Clock4() {
		cout << "destructor:" << H << ":" << M << ":" << S << endl;
	}
	Clock4(Clock4 & p) {
		cout << "copy constructor,before call:" << H << ":" << M << ":" << S << endl;
		H = p.H;
		M = p.H;
		S = p.S;
	}
	void ShowTime() {
		cout << H << ":" << M << ":" << S << endl;
	}
};
Clock4 fun(Clock4 C) {
	return C;
}
int P5_4() {
	Clock4 C1(8, 0, 0);
	Clock4 C2(9, 0, 0);
	Clock4 C3(C1);
	fun(C2);
	Clock4 C4;
	C4 = C2;
	return 0;
}


class String5 {
private:
	char * Str;
	int len;
public:
	void ShowStr() {
		cout << "String:" << Str << ",length:" << len << endl;
	}
	String5() {
		len = 0;
		Str = NULL;
	}
	String5(const char *p) {
		len = strlen(p);
		Str = new char[len + 1];
		strcpy(Str, p);
	}
	~String5()
	{
		if (Str != NULL) {
			delete[]Str;
			Str = NULL;
		}
	}
	String5(String5 & r) {
		len = r.len;
		if (len != 0) {
			Str = new char[len + 1];
			strcpy(Str, r.Str);
		}
	}
};

int P5_5() {
	String5 s1("123456");
	String5 s2 = s1;
	s1.ShowStr();
	s2.ShowStr();
	return 0;
}



class Clock6 {
private:
	int H, M, S;
public:
	void SetTime(int h, int m, int s) {
		H = h, M = m, S = s;
	}
	void ShowTime() {
		cout << H << ":" << M << ":" << S << endl;
	}
	Clock6(int h = 0, int m = 0, int s = 0) {
		H = h, M = m, S = s;
	}
	Clock6(Clock6 & p) {
		H = p.H, M = p.M, S = p.S;
	}
	void TimeAdd(Clock6 *Cp);
	void TimeAdd(int h, int m, int s);
	void TimeAdd(int s);
};
void Clock6::TimeAdd(Clock6 * Cp)
{
	H = (Cp->H + H + (Cp->M + M + (Cp->S + S) / 60) / 60) % 24;
	M = (Cp->M + M + (Cp->S + S) / 60) % 60;
	S = (Cp->S + S) % 60;
}
void Clock6::TimeAdd(int h, int m, int s){
	H = (h + H + (m + M + (s + S) / 60) / 60) % 24;
	M = (m + M + (s + S) / 60)  % 60;
	S = (s + S) % 60;
}
void Clock6::TimeAdd(int s) {
	H = ( H + (M + (s + S) / 60) / 60) % 24;
	M = ( M + (s + S) / 60) % 60;
	S = (s + S) % 60;
}
int P5_6() {
	Clock6 C1;
	Clock6 C2(8, 20, 20);
	C1.TimeAdd(4000);
	C1.ShowTime();
	C2.TimeAdd(&C1);
	C2.ShowTime();
	return 0;
}









const int MaxN = 100;
const double Rate = 0.6;
class Score7 {
private:
	long No;
	char *Name;
	int Peace;
	int Final;
	int Total;
public:
	Score7(long = 0, char * = NULL, int = 0, int = 0, int = 0);
	void Count();
	void ShowScore();
};
Score7::Score7(long no, char * name, int peace, int final, int total) {
	No = no;
	Name = name;
	Peace = peace;
	Final = final;
	Total = total;
}
void Score7::Count() {
	Total = Peace * Rate + Final * (1 - Rate) + 0.5;
}
void Score7::ShowScore() {
	cout << No << "\t" << Name << "\t" << Peace << "\t" << Final << "\t" << Total << endl;
}
int P5_7() {
	Score7 ClassScore1[3];
	Score7 ClassScore2[3] = {
		Score7(200607001,(char *)"LiuNa",80,79),
		Score7(200607002,(char *)"CuiPeng",90,85),
		Score7(200607003,(char *)"ZhouJun",70,55),
	};
	for (int i = 0; i, 3; i++)
		ClassScore2[i].Count();
	for (int i = 0; i, 3; i++)
		ClassScore2[i].ShowScore();
	return 0;
}







class Clock8 {
private:
	int H, M, S;
public:
	void ShowTime() {
		cout << H << ":" << M << ":" << S << endl;
	}
	void SetTime(int H = 0, int M = 0, int S = 0) {
		this->H = H, this->M = M, this->S = S;
	}
	Clock8(int H = 0, int M = 0, int S = 0) {
		this->H = H, this->M = M, this->S = S;
	}
	int GetH() {
		return H;
	}
	int GetM() {
		return M;
	}
	int GetS() {
		return S;
	}
};
class TrainTrip8 {
private:
	char *TrainNo;
	Clock8 StartTime;
	Clock8 EndTime;
public:
	TrainTrip8(char *TrainNo, Clock8 S, Clock8 E) {
		this->TrainNo = TrainNo;
		StartTime = S;
		EndTime = E;
	}
	Clock8 TripTime8() {
		int tH, tM, tS;
		int carry = 0;
		Clock8 tTime;
		(tS = EndTime.GetS() - StartTime.GetS()) > 0 ? carry = 0 : tS += 60, carry = 1;
		(tM = EndTime.GetM() - StartTime.GetM() - carry) > 0 ? carry = 0 : tM += 60, carry = 1;
		(tH = EndTime.GetH() - StartTime.GetH() - carry) > 0 ? carry = 0 : tM += 24;
		return tTime;
	}
};
int P5_8() {
	Clock8 C1(8, 10, 10), C2(6, 1, 2);
	Clock8 C3;
	TrainTrip8 T1((char *)"K16", C1, C2);
	C3 = T1.TripTime8();
	C3.ShowTime();
	return 0;
}











class Student {
private:
	char * Name;
	int No;
	static int countS;
public:
	static int Getcount() {
		return countS;
	}
	Student(char* = (char *)"", int = 0);
	Student(Student &);
	~Student();
};
Student::Student(char * Name, int No) {
	this->Name = new char[strlen(Name) + 1];
	strcpy(this->Name, Name);
	this->No = No;
	++countS;
	cout << "constructing:" << Name << endl;
}
Student::Student(Student & r) {
	Name = new char[strlen(r.Name) + 1];
	strcpy(Name, r.Name);
	No = r.No;
	++countS;
	cout << "copy constructing:" << r.Name << endl;
}
Student::~Student() {
	cout << "destructing:" << Name << endl;
	delete[]Name;
	--countS;
}
int Student::countS = 0;
int P5_9() {
	cout << Student::Getcount() << endl;
	Student s1((char *)"Antony");
	cout << s1.Getcount << endl;
	Student s2(s1);
	cout << s1.Getcount << endl;
	Student s3[2];
	cout << Student::Getcount() << endl;
	Student * s4 = new Student[3];
	cout << Student::Getcount() << endl;
	delete[]s4;
	cout << Student::Getcount() << endl;
	return 0;
}









class Clock10 {
private:
	int H, M, S;
public:
	void ShowTime() {
		cout << H << ":" << M << ":" << S << endl;
	}
	void SetTime(int H = 0, int M = 0, int S = 0) {
		this->H = H, this->M = M, this->S = S;
	}
	Clock10(int H = 0, int M = 0, int S = 0) {
		this->H = H, this->M = M, this->S = S;
	}
	friend Clock10 TripTime(Clock10 & StartTime, Clock10 & EndTime);
};
Clock10 TripTime(Clock10 & StartTime, Clock10 & EndTime) {
	int tH, tM, tS;
	int carry = 0;
	Clock10 tTime;
	(tS = EndTime.S - StartTime.S) > 0 ? carry = 0 : tS += 60, carry = 1;
	(tM = EndTime.M - StartTime.M - carry) > 0 ? carry = 0 : tM += 60, carry = 1;
	(tH = EndTime.H - StartTime.H - carry) > 0 ? carry = 0 : tM += 24;
	tTime.SetTime(tH, tM, tS);
	return tTime;
}
int P5_10() {
	Clock10 C1(8, 10, 10), C2(6, 1, 2);
	Clock10 C3;
	C3 = TripTime(C1, C2);
	C3.ShowTime();
	return 0;
}












class TrainTrip11;
class Clock11 {
private:
	int H, M, S;
public:
	void ShowTime() {
		cout << H << ":" << M << ":" << S << endl;
	}
	void SetTime(int H = 0, int M = 0, int S = 0) {
		this->H = H, this->M = M, this->S = S;
	}
	Clock11(int H = 0, int M = 0, int S = 0) {
		this->H = H, this->M = M, this->S = S;
	}
	friend class TrainTrip11;
};
class TrainTrip11 {
private:
	char * TrainNo;
	Clock11 StartTime;
	Clock11 EndTime;
public:
	TrainTrip11(char * TrainNo, Clock11 S, Clock11 E) {
		this->TrainNo = TrainNo;
		StartTime = S;
		EndTime = E;
	}
	Clock11 TripTime11(){
		int tH, tM, tS;
		int carry = 0;
		Clock11 tTime;
		(tS = EndTime.S - StartTime.S) > 0 ? carry = 0 : tS += 60, carry = 1;
		(tM = EndTime.M - StartTime.M - carry) > 0 ? carry = 0 : tM += 60, carry = 1;
		(tH = EndTime.H - StartTime.H - carry) > 0 ? carry = 0 : tM += 24;
		tTime.SetTime(tH, tM, tS);
		return tTime;
	}
};
int P5_11(){
	Clock11 C1(8, 10, 10), C2(6, 1, 2);
	Clock11 C3;
	TrainTrip11 T1((char *) "K16", C1, C2);
	C3 = T1.TripTime11();
	C3.ShowTime();
	return 0;
}







class A{
private:
	const int & r;
	const int a;
	static const int b;
public:
	A(int i) :a(i), r(a) {
		cout << "constructor!" << endl;
	}
	void display() {
		cout << a << "," << b << "," << r << endl;
	}
};
int P5_12() {
	A a1(1);
	a1.display();
	A a2(2);
	a2.display();
	return 0;
}