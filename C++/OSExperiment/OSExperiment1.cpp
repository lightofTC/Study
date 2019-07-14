// OSExperiment1.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
using namespace std;

int num = 5;

struct PCB
{
	char name[5];          //进程名
	struct PCB* link;      //下一进程首地址
	int rtime;             //已运行时间
	int ntime;             //运行所需总时间
	char state;            //进程状态  R未结束  E已结束
};

int InitPCB(PCB *& P) {
	cout << "请为以下五个进程输入初始信息" << endl;
	P = (PCB*)malloc(sizeof(PCB));
	P->link = NULL;
	PCB* p = P;
	int n = 0;
	while (num--) {
		p = p->link = (PCB*)malloc(sizeof(PCB));
		cout << "请输入第" << n+1 << "个进程的进程名(5字符内),总运行时间,已运行时间：" << endl;
		cin >> p->name >> p->ntime >> p->rtime;
		p->state = 'R';
		p->link = NULL;
		n++;
	}
	p->link = P->link;
	return 0;
}

void Destroy(PCB*&P) {
	PCB*pre = P;
	PCB* p = P->link;
	int n = 5;
	while (p != NULL&&n>0) {
		free(pre);
		pre = p;
		p = p->link;
		n--;
	}
	free(pre);
}

void Output(PCB* P) {
	PCB* p = P->link;
	do {
		if (p->state != 'E') {
			cout << "进程名：" << p->name << "\t总运行时间：" << p->ntime
				<< "\t已运行时间：" << p->rtime << "\t状态：" << p->state << endl;
			p = p->link;
		}
		else
			p = p->link;
	} while (p != P->link);
}

void T(PCB* &P) {
	cout << "\t****************进程正式开始*****************" << endl;
	int flag = 5;                               //记录未结束进程数量
	PCB* p = P->link;
	while (p->ntime > p->rtime) {               //开始轮转
		cout << "正在运行" << p->name << "进程" << endl;
		p->rtime++;
		Output(P);
		if (p->ntime == p->rtime) {            //判断进程是否已结束
			p->state = 'E';
			flag--;
			cout << p->name << "进程运行结束！" << endl;
		}
		p = p->link;
		while (flag && p->ntime == p->rtime)   //跳过已结束的进程
			p = p -> link;
	}
	cout << "\t*******************进程运行结束*******************";
}
int main()
{
	PCB*P;
	InitPCB(P);
	Output(P);

	T(P);

	Destroy(P);
    
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
