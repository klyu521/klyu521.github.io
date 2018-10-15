using System;
/// <summary>
/// A FIFO queue interface.  
/// linked queue.
/// </summary>
public interface IQueueInterface<T>
{
	/// <summary>
	/// Add an element to the rear of the queue
	/// </summary>
	/// <returns> the element that was enqueued </returns>
	T Push(T element);

	/// <summary>
	/// Remove and return the front element.
	/// </summary>
	/// <exception cref="Thrown"> if the queue is empty </exception>
//JAVA TO C# CONVERTER WARNING: Method 'throws' clauses are not available in .NET:
//ORIGINAL LINE: T pop() throws QueueUnderflowException;
	T Pop();

	/// <summary>
	/// Test if the queue is empty
	/// </summary>
	/// <returns> true if the queue is empty; otherwise false </returns>
	bool Empty {get;}
}




