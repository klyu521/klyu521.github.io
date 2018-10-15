

public class LinkedQueue<T> : IQueueInterface<T>
{
	private Node<T> front;
	private Node<T> rear;

	public LinkedQueue()
	{
		front = null;
		rear = null;
	}

	public virtual T Push(T element)
	{
		if (object.Equals(element, default(T)))

        {
			throw new System.NullReferenceException();
		}

		if (Empty)
		{
			Node<T> tmp = new Node<T>(element, null);
			rear = front = tmp;
		}
		else
		{
			// General case
			Node<T> tmp = new Node<T>(element, null);
			rear.next = tmp;
			rear = tmp;
		}
		return element;
	}

	public virtual T Pop()
	{
		T tmp = default;
		if (Empty)
		{
			throw new QueueUnderflowException("The queue was empty when pop was invoked.");
		}
		else if (front == rear)
		{ // one item in queue
			tmp = front.data;
			front = null;
			rear = null;
		}
		else
		{
			// General case
			tmp = front.data;
			front = front.next;
		}

		return tmp;
	}

	public virtual bool Empty
	{
		get
		{
			if (front == null && rear == null)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}

}

