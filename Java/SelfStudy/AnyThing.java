
public class AnyThing {

	public AnyThing() {
		this("this调用有参数构造方法");
		System.out.println("无参数构造方法");
	}
	
	public AnyThing(String name) {
		System.out.println("有参数构造方法");
	}
	
	public static void main(String[] args) {
		AnyThing anything;
	}
}
