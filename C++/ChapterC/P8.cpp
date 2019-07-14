#include <iostream>
using namespace std;




template <class T1,class T2>
T1 add(T1 x, T2 y) {
	cout << "(" << sizeof(T1) << "," << sizeof(T2) << ")\t";
	return x + y;
}
int P8_1() {
	cout << add(9, 8) << endl;
	cout << add(9.0, 8.0) << endl;
	cout << add(9, 8.0) << endl;
	cout << add(9.0, 8) << endl;
	cout << add('A', 'A' - '0') << endl;
	cout << add(long(8), 9) << endl;
	return 0;
}








template<class T>
class Stack {
private:
	int size;
	int top;
	T * space;
public:
	Stack(int = 10);
	~Stack() {
		delete[]space;
	}
	bool push(const T&);
	T pop();
	bool IsEmpty()const {
		return top == size;
	}
	bool IsFull()const {
		return top == 0;
	}
};
template<class T>
Stack<T>::Stack(int size) {
	this->size = size;
	space = new T[size];
	top = size;
}
template <class T>
bool Stack<T>::push(const T & element) {
	if (!IsFull()) {
		sapce[--top] = element;
		return ture;
	}
	return false;
}
template<calss T>
T Stack<T>::pop() {
	return space[top++];
}
int P8_2() {
	Stack<char>S1(4);
	S1.push('x');
	S1.push('y');
	S1.push('z');
	S1.push('u');
	S1.push('v');
	while (!S1.IsEmpty())
		cout << S1.pop() << endl;
	return 0;
}







template<class TYPE>
class ListNode {
private:
	TYPE data;
	ListNode * next;
	static ListNode * CurNode;
	static ListNode * head;
public:
	ListNode() {
		next = NULL;
		head = CurNode = this;
	}
	ListNode(TYPE NewData) {
		data = NewData;
		next = NULL;
	}
	void AppendNode(TYPE NewNode);
	void DispList();
	void DelList();
};
template<class TYPE>
ListNode<TYPE> *ListNode<TYPE>::CurNode;
template<class TYPE>
ListNode<TYPE> *ListNode<TYPE>::head;
template<class TYPE>
void ListNode<TYPE>::AppendNode(TYPE NewData) {
	CurNode->next = new ListNode(NewData);
	CurNode = CurNode->next;
}
template<class TYPE>
void ListNode<TYPE>::DispList() {
	CurNode = head->next;
	while (CurNode != NULL) {
		cout << CurNode->data << endl;
		CurNode = CurNode->next;
	}
}
template<class TYPE>
void ListNode<TYPE>::DelList() {
	ListNode * q;
	CurNode = head->next;
	while (CurNode != NULL) {
		q = CurNode->next;
		delete CurNode;
		CurNode = q;
	}
	head->next = NULL;
}
int P8_3() {
	ListNode<char>CList;
	CList.AppendNode('A');
	CList.AppendNode('B');
	CList.AppendNode('C');
	CList.DispList();
	CList.DelList();
	CList.DispList;
	return 0;
}