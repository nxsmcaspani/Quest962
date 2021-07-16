using System;

class Character {
  private string charName;
  private int lifePoints;
  private int attPoints;
  private int defPoints;

  public string GetCharName(){
    return this.charName;
  }

  public void SetCharName(string charName){
    this.charName = charName;
  }

  public int GetLifePoints(){
    return this.lifePoints;
  }

  public void SetLifePoints(int lifePoints){
    this.lifePoints = lifePoints;
  }

  public int GetAttPoints(){
    return this.attPoints;
  }

  public void SetAttPoints(int attPoints){
    this.attPoints = attPoints;
  }

  public int GetDefPoints(){
    return this.defPoints;
  }

  public void SetDefPoints(int defPoints){
    this.defPoints = defPoints;
  }

  public void Attack(Character attacker){
    if(!this.isAlive()){
      Console.WriteLine(this.GetCharName() + " is already dead... [R.I.P]");
    } else {
      Console.WriteLine(this.GetCharName() + " is attacked by "+attacker.GetCharName());
      this.SetLifePoints(this.GetLifePoints()-(attacker.GetAttPoints()-this.GetDefPoints()));
      if(!this.isAlive()){
        Console.WriteLine (this.GetCharName() + " died. " + attacker.GetCharName() + " won the fight!");
      }
    }
  }

  private bool isAlive(){
    if(this.GetLifePoints() > 0){
      return true;
    } else return false;
  }

  public static void Main (string[] args) {
    Character thanos = new Character();
    Character thor = new Character();
    thanos.SetCharName("Thanos");
    thanos.SetAttPoints(50);
    thanos.SetDefPoints(30);
    thanos.SetLifePoints(1200);
    thor.SetCharName("Thor");
    thor.SetAttPoints(65);
    thor.SetDefPoints(45);
    thor.SetLifePoints(1000);
    Console.WriteLine("Today's fight: "+thanos.GetCharName()+" VS "+thor.GetCharName());
    // Let's use some random number generation to spice up the fight
    Random _random = new Random();
    while(thanos.GetLifePoints() > 0 && thor.GetLifePoints() >0){       
      if(_random.Next(0, 100) < 50){
        thanos.Attack(thor);
      } else thor.Attack(thanos);
    }    
  }
}