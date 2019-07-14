#include <iostream>
#include<complex>
#include<string>
using namespace std;




int P10_1() {
	char * s1 =(char *) "a c string";
	string s2("a c++string");
	complex<double>c(3.14159, -1.234);
	int i(10);
	int * pi = &i;
	cout << s1 << endl
         << s2 << endl;
	cout << c << endl;
	cout << i++ << '\t'
		<< i++ << '\t'
		<< i++ << endl;
	cout << "&i:" << &i << '\t'
		<< "pi:" << pi << endl;
	cout << "&s1:" << &s1 << &s1 << '\t'
		<< "s1:" << const_cast<void *>(s1) << endl
		<< "s1:" << (void *)s1 << endl;
	return 0;
}






int P10_2() {
	int val1(10), val2(20);
	cout << "the larger of " << val1 << "," << val2 << " is:";
	cout << (val1 > val2) ? val1 : val2;
	return 0;
}






struct fmtflag {
	long flag;
	char flagname[12];
}flags[18]{ {ios::hex,"hex"},
{ios::dec,"dec"},
{ios::oct,"oct"},
{ios::basefield,"basefield"},
{ios::internal,"internal"},
{ios::left,"left"},
{ios::right,"right"},
{ios::adjustfield,"adjustfield"},
{ios::scientific,"scientific"},
{ios::basefield,"basefield"},
{ios::showbase,"showbase"},
{ios::showpoint,"showpoint"},
{ios::showpos,"showpos"},
{ios::skipws,"skipws"},
{ios::uppercase,"uppercase"},
{ios::boolalpha,"boolalpha"},
{ios::unitbuf,"unitbuf"},
};
int P10_3() {
	long IFlags;
	IFlags = cout.setf(0, cout.flags());
	cout << "Default flag is:" << IFlags << endl;
	for (int i = 0; i < 18; i++)
		cout << flags[i].flag << '\t' << flags[i].flagname << endl;
	return 0;
	)
}