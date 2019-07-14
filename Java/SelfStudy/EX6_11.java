
public class EX6_11 {

	public static void main(String[] args) {
		int arr2[][]= {{4,3},{1,2}};
		System.out.println("数组中的元素是：");
		int i=0;
		for(int x[]:arr2) {
			i++;
			int j=0;
			for(int e:x) {
				j++;
				if(i==arr2.length && j==x.length) {
					System.out.print(e);
				}else
					System.out.print(e+"、");
			}
		}

	}

}
