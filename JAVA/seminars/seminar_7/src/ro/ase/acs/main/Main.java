package ro.ase.acs.main;

import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

import ro.ase.acs.classes.Sum;
import ro.ase.acs.interfaces.BinaryOperator;
import ro.ase.acs.interfaces.Movable;
import ro.ase.acs.interfaces.UnaryOperator;

public class Main {

	public static void main(String[] args) {
		BinaryOperator operator = new Sum();
		operator = new BinaryOperator() {
			
			@Override
			public double operate(double operand1, double operand2) {
				return  operand1 - operand2;
			}
		};
		
		System.out.println(operator.operate(3, 5));
		
		
		operator = (o1, o2)->o1*o2;
		
		System.out.println(operator.operate(3, 6));
		
		Movable m = ()-> System.out.println("The car is moving");
		m.move();
		
		UnaryOperator op = o -> ++o;
		
		System.out.println(op.operate(5));
		
		List<Integer> list = Arrays.asList(1,4,5,12,8,4);
		
		long nb = list.stream().distinct().filter(e-> e<9).count();
		
		System.out.println(nb);
		List<Integer> newList = list.stream().filter(e-> e % 2 == 1).collect(Collectors.toList());
		
		for(Integer i: newList) {
			System.out.println(i);
		}
		
		List<String> stringList = Arrays.asList("someting", "Something else", "a", "abs");
		String FiltredStrings = stringList .stream().filter(s->s.length()>2).sorted().collect(Collectors.joining((", ")));
		System.out.println(FiltredStrings);
		
		list.stream().distinct().map(n -> n*n).forEach(n->System.out.println(n));
	}

}
