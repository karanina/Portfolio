package io.github.karanina.exercises.model;

import android.util.Log;

import com.google.gson.annotations.SerializedName;

import java.util.List;

public class Drinks {

    public List<Drink> drinks;
//    public List<Drink> getValue(int position){ return (List<Drink>) drinks.get(position); }
    public List<Drink> getValue(){ return (this.drinks); }
    public Drink getValue(int i){return (this.drinks.get(i));}
    public void setValue(List<Drink> value) {
        this.drinks = value;
    }

    public int size() {
        try {
            return drinks.size();
        }
        catch (NullPointerException e){
            e.printStackTrace();
            Log.d("COCKTAIL_COUNT", "null object");
            e.printStackTrace();
        }
        return 0;
    }
}
