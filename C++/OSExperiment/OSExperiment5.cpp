// ConsoleApplication1.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
#include "math.h"
#include<stdio.h>
#include<stdlib.h>
#include<string.h>
#define num 10
using namespace std;

struct PCB {
	char state;         //阻塞W，就绪R，运行E，完成C
	int reason;        //1等待信号empty1，2等待信号full
	int breakPoint;
	const char*procedure;
};

PCB pro; PCB*proNode = &pro;
PCB cus; PCB*cusNode = &cus;
char i[100];
char x, c; 
char B[num + 1];//存放商品
int PC, sum, in, out;
int a, empty1, full;
int tag, reTag;
int stop;      
int(*PA[5])(int *s, PCB*P);
int(*SA[5])(int*s, PCB*P);
bool message;
bool mutexP; bool mutexC;

int W(int*s, PCB*q) {
	tag = 0;
	q->state = 'W';
	//cout <<  q->procedure ;
	if (strcmp(q->procedure, "生产者") == 0) {
		cout << "生产者进程被阻塞\n\n";
	}
	else {
		cout << "消费者进程被阻塞\n\n";
	}
	q->reason = 2;
	stop = 0;
	return 0;
}

int R(int*s, PCB*q) {
	//cout << q->procedure;
	if (strcmp(q->procedure, "生产者") == 0) {
		cout << "生产者进程已唤醒\n";
		q->state ='R';
	}
	else {
		cout << "消费者进程已唤醒\n";
		q->state = 'R';
	}
	q->state = 'R';
	q->reason = 0;
	return 0;
}

int ProducerP(int*m, PCB*q) {
	message = true;
	mutexC = false;
	stop = 1;
	*m = *m - 1;
	if (*m < 0) {
		W(m, q);
		message = false;
		mutexC = true;
	}
	else
		stop = 0;
	tag = 0;
	if (message)
		cout << "生产者占用共享资源！\n";
	q->breakPoint = PC;
	return 0;
}

int CustomerP(int *m, PCB*q) {
	message = true;
	mutexP = false;
	stop = 1;
	*m = *m - 1;
	if (*m < 0) {
		W(m, q);
		message = false;
		mutexP = true;
	}
	else
		stop = 0;
	tag = 0;
	if (message)
		cout << "消费者占用共享资源！\n";
	q->breakPoint = PC;
	return 0;
}

int ProducerV(int *m, PCB*q) {
	stop = 1;
	mutexC = true;
	cout << "生产者释放共享资源\n\n";
	*m = *m + 1;
	if (*m <= 0)
		R(m, q);
	stop = 0;
	tag = 0;
	if (q->state != 'C')
		q->state = 'R';
	proNode->breakPoint = PC;
	
	return 0;
}



int CustomerV(int *m, PCB*q) {
	stop = 1;
	mutexP = true;
	cout << "消费者释放共享资源\n\n";
	*m = *m + 1;
	if (*m <= 0)
		R(m, q);
	stop = 0;
	tag = 0;
	if (q->state != 'C')
		q->state = 'R';
	cusNode->breakPoint = PC;
	
	return 0;

}

int Put(int *s, PCB*pro) {
	in = (in + 1) % 10;
	B[in] = c;
	cout << "生产者已把商品"<<B[in]<<"放入缓存中！\n";
	pro->breakPoint = PC;
	return 0;
}

int Get(int *s, PCB*cus) {
	out = (out + 1) % 10;
	x = B[out];
	cus->breakPoint = PC;
	cout << "消费者取出商品" << x << "\n";
	return 0;
}

int Consume(int*s, PCB*q) {	
	q->breakPoint = PC;
	if (x == i[sum - 1])
		return 1;
	return 0;
}

int Produce(int*s, PCB*q) {
	a++;
	if (a == sum) {
		reTag = 1;
		return 0;
	}
	else {
		c = i[a];
		cout << "生产者生产商品" << c << endl;
		q->breakPoint = PC;
		return 0;
	}
}

int Goto(int*s, PCB*q) {
	q->breakPoint = PC;
	PC = 0;
	return 0;
}

int InitPro() {
	PA[0] = Produce;
	PA[1] = ProducerP;
	PA[2] = Put;
	PA[3] = ProducerV;
	PA[4] = Goto;
	return 0;
}

int InitCus(){
	SA[0] = CustomerP;
	SA[1] = Get;
	SA[2] = CustomerV;
	SA[3] = Consume;
	SA[4] = Goto;
	return 0;
}

int CodePro(int *empty1, int *full, PCB*pro, PCB*cus) {
	switch (PC)
	{case 0:
		PA[PC](&PC, pro); 
		break;
	case 1:
		PA[PC](empty1, pro);
		break;
	case 2:
		PA[PC](&in, pro);
		break;
	case 3:
		PA[PC](full, cus);
		break;
	case 4:
		PA[PC](empty1, pro);
		break;
	}
	return 0;
}

int CodeCus(int *empty1, int *full, PCB*pro, PCB*cus) {
	switch (PC) {
	case 0:
		SA[PC] (full,cus);
		break;
	case 1:
		SA[PC](&out, cus);
		break;
	case 2:
		SA[PC](empty1, pro);
		break;
	case 3:
		SA[PC](full, cus);
		break;
	case 4:
		SA[PC](full, cus);
		break;
	}
	return 0;
}

int Control(int *empty1, int *full, PCB*pro, PCB*cus) {
	int random = rand()%2;
	if (random == 0 && reTag == 0 && pro->state != 'W') {
		if (mutexP == true) {
			PC = (pro->breakPoint + 1) % 5;
			CodePro(empty1, full, pro, cus);
		}
		else
			cout << "生产者请求资源失败！\n";
			
	}
	else if ((random == 1 || reTag == 1) && cus->state != 'W') {
		if (mutexC == true) {
			PC = (cus->breakPoint + 1) % 5;
			CodeCus(empty1, full, pro, cus);
		}
		else
			cout << "消费者请求资源失败！\n";
	}
	return 0;
}

int InitPCB(PCB*pro) {
	pro->breakPoint = -1;
	pro->state = 'R';
	pro->reason = 0;
	return 0;
}

void Init() {
	empty1 = 10; full = 0; in = 0; out = 0;
	PC = 0, a = -1; tag = 0; stop = 0; reTag = 0;
	mutexP = true; mutexC = true;
	cout << "请输入产品名，用字符串表示：\n";
	cin >> i;
	sum = strlen(i);
}
int main()
{
	Init();
	pro.procedure = "生产者";
	cus.procedure = "消费者";
	InitPCB(&pro); InitPCB(&cus);
	InitPro(); InitCus();
	Control(&empty1, &full, &pro, &cus);
	while(B[out]!=i[sum-1])
		Control(&empty1, &full, &pro, &cus);
	Control(&empty1, &full, &pro, &cus);
	cout << "程序结束！\n";
	return 0;
}

// 运行程序: Ctrl + F5 或调试 >“开始执行(不调试)”菜单
// 调试程序: F5 或调试 >“开始调试”菜单

// 入门提示: 
//   1. 使用解决方案资源管理器窗口添加/管理文件
//   2. 使用团队资源管理器窗口连接到源代码管理
//   3. 使用输出窗口查看生成输出和其他消息
//   4. 使用错误列表窗口查看错误
//   5. 转到“项目”>“添加新项”以创建新的代码文件，或转到“项目”>“添加现有项”以将现有代码文件添加到项目
//   6. 将来，若要再次打开此项目，请转到“文件”>“打开”>“项目”并选择 .sln 文件
