public interface Ivulnerable
{
     void hurt();
}

public interface IHitter
{
    void hit(Ivulnerable other);
}


public interface Ipickupable
{
    void pickedUp();
}