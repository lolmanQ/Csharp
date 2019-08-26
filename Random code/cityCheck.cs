using System;

class MainClass {
	public bool isExit;
  static void Main () {
		mloop mlop = new mloop();
  	bool first = true;
		if(first){
			Console.WriteLine("if you want to exit type exit at any point");
			first = false;
		}
		mlop.mL();
  }
  
}

class mloop{
	loop lop = new loop();
	MainClass MC = new MainClass();
	public void mL() {
  	if(MC.isExit){
		}
		else{
			MC.isExit = lop.MainL();
			mL();
		}
  }
}

class loop{
	public bool MainL () {
		inputClassCity inP = new inputClassCity();
		register reg = new register();
		MainClass MC = new MainClass();
		MC.isExit = inP.inputGet();
		if(MC.isExit){
			return true;
		}
	 	else if(reg.cityCheck(inP.cityIn)){
			Console.WriteLine(inP.cityIn + " is in the register");
		}
		else{
			Console.WriteLine(inP.cityIn + "is not in the register");
		}
		return false;
  }
}

class inputClassCity {
	public string cityIn;

	public bool inputGet(){
		Console.WriteLine("Enter your city");
		cityIn = Console.ReadLine();
		if(cityIn == "exit"){
			return true;
		}
		else{
			return false;
		}
	}
}

class register {
	string [] cityAr = new string [] {
		"vaxjo",
		"alvesta",
		"gemla"
	};
	
	public bool cityCheck(string city){
		foreach(string cityFromList in cityAr){
			if(cityFromList == city){
				return true;
			}
		}
		return false;
	}
}