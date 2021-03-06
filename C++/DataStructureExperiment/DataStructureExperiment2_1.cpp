// DataStructureExperiment2_1.cpp : 此文件包含 "main" 函数。程序执行将在此处开始并结束。
//

#include "pch.h"
#include <iostream>
#include <cstdlib>
#include <iterator>
#include <algorithm>
#include <vector>
using namespace std;

typedef struct Stack
{
	char e;
	struct Stack *next;
}stk;

class stack
{
public:
	stack()
	{
		cout << "Hey,asshole!\n";
		head = (stk *)malloc(sizeof(stk));
		head->next = NULL;
	};

	int stackPush(char p);
	int stackPop(char *p);
	char stackGet(char *p);
	int IsNotEmpty();
	void stackprint();
	~stack()
	{
		cout << "Holyshot!\n";
		free(head);
	}
private:
	stk *head;
};

int stack::stackPush(char p)
{
	stk *t;
	if ((t = (stk *)malloc(sizeof(stk))) == NULL)
	{
		cout << "No enough memory!" << endl;
		return 0;
	}
	t->e = p;
	t->next = head->next;
	head->next = t;
	return 1;
}

int stack::stackPop(char *p)
{
	stk *t;
	t = head->next;
	if (t == NULL)
	{
		cout << "The stack is already empty!" << endl;
		return 0;
	}

	head->next = t->next;
	*p = t->e;
	free(t);
	return 1;
}

void stack::stackprint()
{
	stk *t;
	t = head->next;
	while (t != NULL)
	{
		cout << ' ' << t->e << endl;
		t = t->next;
	}
}

char stack::stackGet(char * p)
{
	*p = head->next->e;
	return *p;
}

int stack::IsNotEmpty()
{
	if (head->next != NULL) return 1;
	else
		return 0;
}

int main()
{
	stack mystack;
	char p;

	vector<char> data;
	//copy(istream_iterator<char>(cin),istream_iterator<char>(),back_inserter(data));
	while (cin >> p && p != 'a') //输入以a结束，且a不计算在内
		data.push_back(p);
	//cout<<endl;
	copy(data.begin(), data.end(), ostream_iterator<char>(cout));
	for (vector<char>::iterator i(data.begin()); i != data.end(); ++i)
	{
		if ((*i == '(') || (*i == '[') || (*i == '{'))
			mystack.stackPush(*i);
		else if (*i == ')' && mystack.stackGet(&p) == '(')
			mystack.stackPop(&p);
		else if (*i == ']' && mystack.stackGet(&p) == '[')
			mystack.stackPop(&p);
		else if (*i == '}' && mystack.stackGet(&p) == '{')
			mystack.stackPop(&p);
		else
			break;
	}

	if (mystack.IsNotEmpty())
		cout << "Does't matter!" << endl;
	else
		cout << "matters well!" << endl;
	return 1;
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
