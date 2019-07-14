// OSExperiment3.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
#include "OSExperiment3.h"
#define MAX 64
using namespace std;


struct BitMap {
	int id;
	char name[20];
	int num;           //分配的磁盘块的数量
	int array[10];     //记录文件分配的具体块号
	struct BitMap *next;
};

int memory[8][8] = {0};      //位示图
BitMap*Memory = NULL;
int work;
int x, y;

void Insert(BitMap*B,int num) {
	BitMap*b;
	b = Memory;
	if (Memory == NULL) {
		Memory = B;
	}
	else {
		while (b->next) {
			b = b->next;
		}
		b->next = B;
	}
	for (int m = 0; m < num; m++) {
		memory[(B->array[m] / 10)][(B->array[m] - 10 * (B->array[m] / 10))] = 1;
	}	
}

void Delete(int id) {
	BitMap*p=NULL, *n=NULL;
	p=n = Memory;
	if (n->id == id) {
		for (int m = 0; m < n->num; m++) {
			memory[(n->array[m] / 10)][(n->array[m] - 10 * (n->array[m] / 10))] = 0;
		}
		Memory = n->next;
		free(p);
	}
	else {
		while (n->id != id) {
			p = n;
			n = n->next;
		}

		for (int m = 0; m < n->num; m++) {
			memory[(n->array[m] / 10)][(n->array[m] - 10 * (n->array[m] / 10))] = 0;
		}
		p->next = n->next;
		free(n);
	}
}

void PrintWork() {
	BitMap*b = NULL;
	b = Memory;
	cout << "\n文件号\t文件名\t总共分配的磁盘块数\n";
	cout << "---------------------\n";
	while (b) {
		cout << "\n" << b->id << "\t" << b->name << "\t" << b->num << "\n";
		b = b->next;
	}
	cout << "---------------------\n";
}

void PrintBitMap(int a,int id) {
	switch (a) {
	case 1:
		BitMap*b;
		b = Memory;
		while (b->id != id) {
			b = b->next;
		}
		cout << "---------------------" << b->id << "号文件具体位置----------------------\n";
		cout << "柱面号\t磁道号\t物理记录号\t状态\n";
		cout << "---------------------\n";
		for (int m = 0; m < b->num; m++) {
			x = b->array[m] / 10;
			y = b->array[m] - 10 * x;
			cout << x << "\t" << y / 4 << "\t" << y % 4 << "\t\t";
			if (memory[x][y] != 1)
				cout << "未分配\n";
			else
				cout << "---已分配\n";
		}
		cout << "---------------------\n";
		break;
	case 0:
		cout << "柱面号\t磁道号\t物理记录号\t状态\n";
		cout << "---------------------\n";
		for (int i = 0; i < 8; i++) {
			for (int j = 0; j < 8; j++) {
				cout << i << "\t" << j/4 << "\t" << j % 4 << "\t\t";
				if (memory[i][j] == 1)
					cout << "---已分配\n";
				else
					cout << "未分配\n";
			}
		}
		cout << "---------------------\n";
		break;
	}
	
}

void Init() {
	BitMap*B;
	B = (BitMap*)malloc(sizeof(BitMap));
	B->id = 1; B->num = 2; B->next = NULL; B->array[0] = 41; B->array[1] = 25; strcpy_s(B->name,"SSD1");
	Insert(B,2);
	B = (BitMap*)malloc(sizeof(BitMap));
	B->id = 2; B->num = 3; B->next = NULL; B->array[0] = 71; B->array[1] = 64; B->array[2] = 52; strcpy_s(B->name, "OS");
	Insert(B,3);
	work = 2;
	PrintWork();
	while (1)
	{
		cout << "请输入您想要的操作：新增文件（0） 回收文件（1） 打印所有存储文件（2）\n\t\t    打印文件存储具体位置（3）打印位示图（4）\n";
		int input;
		cin >> input;
		switch (input)
		{		
		case 0:
			cout << "请分别输入文件要分配的磁盘数、文件名：\n";
			BitMap*B;
			B = (BitMap*)malloc(sizeof(BitMap));
			B->id = work + 1; B->next = NULL; work++;
			cin >> B->num>>B->name;
			for (int i = 0; i < B->num; i++) {
				cout << "请输入磁盘的存入位置：\n";
				cin >> B->array[i];
				}
			Insert(B,B->num);
			cout << B->name << "已经分配外存完毕\n";
			PrintWork();
			break;
		case 1:
			cout << "请输入要删除的文件序列号：\n";
			cin >> input;
			Delete(input);
			cout << "文件删除完毕！\n";
			PrintWork();
			break;
		case 2:
			PrintWork();
			break;
		case 3:
			cout << "请输入要打印的文件号：\n";
			int print;
			cin >> print;
			PrintBitMap(1,print);
				break;
		case 4:
			PrintBitMap(0, print);
		default:
			break;
		}
	}
}

int main()
{
	Init();
	
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
