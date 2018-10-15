﻿using System;
/// <summary>
/// Singly linked node class. </summary>

public class Node<T>
{
	public T data;
	public Node<T> next;

	public Node(T data, Node<T> next)
	{
		this.data = data;
		this.next = next;
	}
}
