using System;
class Person
{ 
 public Person()
{
    name = "";
    familia = "";
    brithday = 0;
}

    private string name;
    private string familia;
    private DateTime brithday;

    public Person (string konstruktor1, string konstruktor2, Datetime konstruktor3)
    {
       name = konstruktor1;
        familia= konstruktor2;
        brithday= konstruktor3;

    }
        public string familia
    {
        get
        {
            return this.familia;
        }
        set
        {
            this.familia = value;
        }
          public DateTime brithday
    {
        get
        {
            return this.brithday;
        }
        set
        {
            this.brithday = value;
        }
                public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            this.name = value;
        }
        public int yearbrithday
    {
        get  
        {
            return this.brithday.Year;
        }
        set 
        {
            this.brithday = new DateTime(yearbrithday, this.brithday.Month, this.brithday.Day);
        }
    }
    public string ToFullString
    {
     return string.concat(this.name, this.familia, this.brithday.ToString());

    }
  public string ToShortString
    {
     return string.concat(this.name, this.familia);

    }



}



