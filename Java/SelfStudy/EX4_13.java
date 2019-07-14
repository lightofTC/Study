
public class EX4_13 {

	public static void main(String[] args) {
		// TODO 自动生成的方法存根

		int arr[]= {7,10,1};
		System.out.println("一位数组中的元素分别为：");
		for (int x:arr) {
			System.out.println(x);
		}
		
		String s1=new String("Hello");
		String s2=new String("World");
		String s3=s1+" "+s2;
		System.out.println(s3+" "+s3.length());
		int location1=s3.indexOf("o");
		int location2=s3.lastIndexOf("o");
		char word=s3.charAt(7);
		System.out.println(location1+" "+location2+" "+word);
		String subString1=s3.substring(3);

	}

}
