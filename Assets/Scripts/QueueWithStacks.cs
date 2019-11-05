using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class QueueWithStacks : MonoBehaviour
{

	private Stack<int> PullStack;
	private Stack<int> PushStack;

	public void Start()
	{
		PullStack = new Stack<int>();
		PushStack = new Stack<int>();

		Push(1);
		Push(2);
		Pop();
		Push(3);
		Push(4);
		Pop();
		int x = Peek();
		print(Empty());
	}

	// Push element x to the back of queue.
	public void Push(int x)
	{
		if (PullStack.Count == 0)
			PullStack.Push(x);
		else
			PushStack.Push(x);
		PrintStacks();
	}

	// Removes the element from front of queue.
	public void Pop()
	{
		PullStack.Pop();
		if (PullStack.Count == 0)
		{
			// Pass all elements of the pushStack to the pullStack
			int c = PushStack.Count;
			for (int i = 0; i < c; i++)
			{
				PullStack.Push(PushStack.Pop());
			}
		}
		PrintStacks();
	}

	// Get the front element.
	public int Peek()
	{
		return PullStack.Peek();
	}

	// Return whether the queue is empty.
	public bool Empty()
	{
		return PullStack.Count == 0 && PushStack.Count == 0;
	}

	private void PrintStacks()
	{
		int[] stack1 = PullStack.ToArray();
		int[] stack2 = PushStack.ToArray();
		string s1 = "", s2 = "";
		for (int i = 0; i < stack1.Length; i++)
		{
			s1+=stack1[i] + " ";
		}
		for (int i = 0; i < stack2.Length; i++)
		{
			s2+=stack2[i] + " ";
		}
		print(s1 + " | " + s2);
	}
}
