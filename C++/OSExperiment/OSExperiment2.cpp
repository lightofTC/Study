// OSExperiment2.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>

using namespace std;

struct PCB {
	int start;             //起始地址
	int length;            //作业长度
	int state;             //作业状态  0-未分配  1...n-已分配
	struct PCB*next;       //下一作业地址
};


PCB*Y = NULL, *N = NULL;
int processCount;

void insert(PCB*P) {
	PCB*p;
	p = Y;
	if (Y == NULL) {
		Y = P;
	}
	else {
		while (p->next) {
			p = p->next;
		}
		p->next = P;
	}
}

void insertSpare(PCB*P) {
	PCB*p = NULL, *pre = NULL;
	p = pre = N;
	if (N == NULL) {
		N = P;
	}
	else if (p->start > P->start) {
		P->next = p;
		N = P;
	}
	else {
		p = p->next;
		while (p) {
			if (p->start > P->start) {
				break;
			}
			pre = p; p = p->next;
		}
		P->next = p;
		pre->next = P;
	}
}

void Print() {
	PCB*p = NULL;
	p = N;
	cout << "\n空闲分区表：\n开始地址\t作业长度\t分配状态\n";
	while (p) {
		cout << p->start << "\t\t" << p->length;
		if (p->state == 0)
			cout << "\t\t未分配\n";
		p = p->next;
	}
	p = Y;
	cout << "\n已分配分区表：\n作业序号\t开始地址\t作业长度\t分配状态\n";
	while (p) {
		cout <<p->state<<"\t\t"<< p->start << "\t\t" << p->length;
		if (p->state)
			cout << "\t\t已分配\n";
		p = p->next;
	}
}

void Recover(int id) {
	PCB*p = NULL, *pre = NULL;
	p = pre = Y;
	while(p) {
		if (p->state == id)
			break;
		pre = p;
		p = p->next;
	}
	if (p == NULL)
		cout << "内存中无该作业！\n";
	else {
		if (p == Y)
			Y = p->next;
		else
			pre->next = p->next;
		PCB*temp = N;
		int flag = 0;
		if (p->start + p->length == temp->start) {  //第一个下相邻合并
			flag = 1;
			temp->start = p->start;temp->length += p->length;
		}
		else {
			while (temp->next) {
				if (temp->start + temp->length == p->start) {
					flag = 1;
					if (p->start + p->length == temp->next->start) {   //上、下相邻
						temp->length = temp->length + p->length + temp->next->length;
						PCB *tp = temp->next;
						temp->next = temp->next->next;
						free(tp);
					}
					else   //只上相邻
						temp->length = temp->length + p->length;
					break;
				}
				if (p->start + p->length == temp->next->start) {   //只下相邻
					flag = 1;
					temp->next->start = p->start;
					temp->next->length += p->length;
					break;
				}
				temp = temp->next;
			}
			if(flag == 0) {
				if (temp->start + temp->length == p->start) {
					temp->length += p->length;
				}
				else {
					PCB*P = (PCB*)malloc(sizeof(PCB));
					P->start = p ->start; P->length = p->length; P->state = 0;
					P->next = NULL;
					cout << "插入" << P->start;
					insertSpare(P);
				}
			}
		}
	}
	free(p);
}

void Delete() {
	PCB*pre, *p;
	p = pre = N;
	if (p->length == 0) {
		N = p->next;
		free(p);
	}
	else {
		while (p) {
			if (p->length == 0)
				break;
			pre = p;
			p = p->next;
		}
		if (p) {
			pre->next = p->next;
			free(p);
		}
	}
}

void InitPCB() {
	PCB *P;
	P = (PCB*)malloc(sizeof(PCB));
	P->start = 0; P->length = 21; P->state = 0; P->next = NULL;
	insertSpare(P);
	P = (PCB*)malloc(sizeof(PCB));
	P->start = 21; P->length = 14; P->state = 1; P->next = NULL;
	insert(P);
	P = (PCB*)malloc(sizeof(PCB));
	P->start = 35; P->length = 50; P->state = 0; P->next = NULL;
	insertSpare(P);
	P = (PCB*)malloc(sizeof(PCB));
	P->start = 85; P->length = 43; P->state = 2; P->next = NULL;
	insert(P);
	processCount = 2;

}

int Fit() {
	int select;
	int len, m;
	PCB*p;
	PCB*P = NULL;
	while (1) {
		Print();
		cout << "\n请选择你的操作：1（装入新作业） 2（回收作业）";
		cin >> select;
		if (select == 1) {
			cout << "请输入作业长度";
			cin >> len;
			processCount++;
			p = N;
			while (p) {
				if (p->length >= len) {
					break;
				}
				p = p->next;
			}
			if (p == NULL) {
				cout << "内存空间不足，该作业无法装入!\n";
				continue;
			}
			P = (PCB*)malloc(sizeof(PCB));
			P->start = p->start; P->length = len; P->next = NULL; P->state = processCount;
			insert(P);
			p->start = p->start + len;
			p->length = p->length - len;
			Delete();
		}
		else if (select == 2) {
			cout << "请输入需要回收的作业序号：\n";
			cin >> m;
			Recover(m);
		}
	}
	return 1;
}

int main()
{
	InitPCB();
	Fit();
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
