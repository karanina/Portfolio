package io.github.karanina.exercises.model;

import com.google.firebase.database.Exclude;

import java.io.Serializable;

import io.github.karanina.exercises.R;

public class Favourite extends Drink implements Serializable {
    @Exclude // don't save this property into the database
    private String key;

    public Favourite() {
    }

    public Favourite(Drink drink){
        this.idDrink = drink.getIdDrink();
        this.strDrink = drink.getStrDrink();
        this.strDrinkAlternate = drink.strDrinkAlternate;
        this.strDrinkThumb = drink.getStrDrinkThumb();
        this.strGlass = drink.getStrGlass();
        this.strInstructions = drink.getStrInstructions();
        this.strIngredient1 = drink.getStrIngredient1();
        this.strIngredient2 = drink.getStrIngredient2();
        this.strIngredient3 = drink.getStrIngredient3();
        this.strIngredient4 = drink.getStrIngredient4();
        this.strIngredient5 = drink.getStrIngredient5();
        this.strIngredient6 = drink.getStrIngredient6();
        this.strIngredient7 = drink.getStrIngredient7();
        this.strIngredient8 = drink.getStrIngredient8();
        this.strIngredient9 = drink.getStrIngredient9();
        this.strIngredient10 = drink.getStrIngredient10();
        this.strIngredient11 = drink.getStrIngredient11();
        this.strIngredient12 = drink.getStrIngredient12();
        this.strIngredient13 = drink.getStrIngredient13();
        this.strIngredient14 = drink.getStrIngredient14();
        this.strIngredient15 = drink.getStrIngredient15();
        this.strMeasure1 = drink.getStrMeasure1();
        this.strMeasure2 = drink.getStrMeasure2();
        this.strMeasure3 = drink.getStrMeasure3();
        this.strMeasure4 = drink.getStrMeasure4();
        this.strMeasure5 = drink.getStrMeasure5();
        this.strMeasure6 = drink.getStrMeasure6();
        this.strMeasure7 = drink.getStrMeasure7();
        this.strMeasure8 = drink.getStrMeasure8();
        this.strMeasure9 = drink.getStrMeasure9();
        this.strMeasure10 = drink.getStrMeasure10();
        this.strMeasure11 = drink.getStrMeasure11();
        this.strMeasure12 = drink.getStrMeasure12();
        this.strMeasure13 = drink.getStrMeasure13();
        this.strMeasure14 = drink.getStrMeasure14();
        this.strMeasure15 = drink.getStrMeasure15();
    }

    public String getKey() {
        return key;
    }

    public void setKey(String key) {
        this.key = key;
    }

}
