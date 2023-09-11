package io.github.karanina.exercises.rest;

import android.content.Context;
import android.util.Log;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.squareup.picasso.Picasso;

import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

import io.github.karanina.exercises.AllCocktails;
import io.github.karanina.exercises.AllCocktailsRVAdapter;
import io.github.karanina.exercises.model.Drink;
import io.github.karanina.exercises.model.Drinks;
import retrofit2.Call;
import retrofit2.Response;
import retrofit2.Retrofit;
import retrofit2.converter.gson.GsonConverterFactory;

public class CocktailControllerRESTAPI implements retrofit2.Callback<Drinks>{
    final static String BASE_URL = "http://www.thecocktaildb.com/api/json/v1/1/";
    private static Drinks drinks;
List<Drink> drinkList;
Drink drink = new Drink();
int api_key = 1;
Context context;
AllCocktailsRVAdapter adapter;
RecyclerView rv_allCocktails;
String queryText;
int cocktailID;
ArrayList<View> ingredientViewArrayList;
TextView tv_cocktailRecipe, tv_cocktailAKA, tv_glassType, tv_instructions;
ImageView img_cocktail;

    public void start(Context context, RecyclerView rv_allCocktails) {
        this.context = context;

        this.rv_allCocktails = rv_allCocktails;

        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        CocktailsRESTAPI cocktailsRESTAPI = retrofit.create(CocktailsRESTAPI.class);
            Call<Drinks> call = cocktailsRESTAPI.getAllCocktails("Alcoholic", api_key);
            call.enqueue(this);

    }

    public void start(Context context, RecyclerView rv_allCocktails, String queryText) {
        this.context = context;
        this.queryText = queryText;
        this.rv_allCocktails = rv_allCocktails;

        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .build();
        CocktailsRESTAPI cocktailsRESTAPI = retrofit.create(CocktailsRESTAPI.class);
        Call<Drinks> call = cocktailsRESTAPI.searchAllCocktails(queryText, api_key);
        call.enqueue(this);

    }

    public void start(Context context, int cocktailID, ArrayList<View> ingredientViewArrayList,
                      TextView tv_cocktailRecipe, TextView tv_cocktailAKA, TextView tv_glassType,
                      TextView tv_instructions, ImageView img_cocktail) {
        this.context = context;
        this.cocktailID = cocktailID;
        this.ingredientViewArrayList = ingredientViewArrayList;
        this.tv_cocktailRecipe = tv_cocktailRecipe;
        this.tv_cocktailAKA = tv_cocktailAKA;
        this.tv_glassType = tv_glassType;
        this.tv_instructions = tv_instructions;
        this.img_cocktail = img_cocktail;

        Retrofit retrofit = new Retrofit.Builder()
                .baseUrl(BASE_URL)
                .addConverterFactory(GsonConverterFactory.create())
                .build();

        CocktailsRESTAPI cocktailsRESTAPI = retrofit.create(CocktailsRESTAPI.class);
        Call<Drinks> call = cocktailsRESTAPI.getCocktailByID(cocktailID, api_key);
        call.enqueue(this);
    }


     @Override
    public void onResponse(Call<Drinks> call, Response<Drinks> response) {
        if (response.isSuccessful()) {
            drinks = response.body();
            Log.d("RESPONSE_CODE", "" + response.body());
            Log.d("COCKTAIL_COUNT", "" + drinks.drinks.size());
            if (drinks.drinks.size() == 1){
                drink = drinks.getValue(0);
                Log.d("COCKTAIL_INFO", " Cocktail :" + drink.toString());
                setSingleDrinkActivity(drink);
            }
            else {
                drinkList = drinks.getValue();
                if (drinkList != null)
                    for (Drink drink : drinkList) {
                        Log.d("COCKTAIL_INFO", " Cocktail :" + drink.toString());
                    }
                rv_allCocktails.setLayoutManager(new LinearLayoutManager(context));
                adapter = new AllCocktailsRVAdapter(context);
                adapter.setItems((ArrayList<Drink>)drinkList);
                rv_allCocktails.setAdapter(adapter);
                Log.d("COCKTAIL_Count", " Cocktail Count " + "" + drinks.drinks.size());
            }
        } else {
            Log.d("COCKTAIL_CODE", "" + response.code());
        }
    }

    private void setSingleDrinkActivity(Drink drink) {
        tv_cocktailRecipe.setText(drink.getStrDrink());
        Picasso.get().load(drink.getStrDrinkThumb()).into(img_cocktail);
        if (drink.getStrDrinkAlternate() != null) {
            String cocktailAKA;
            cocktailAKA = "This cocktail is also known as "
                    + drink.getStrDrinkAlternate();
            tv_cocktailAKA.setText(cocktailAKA);
        } else {
            tv_cocktailAKA.setVisibility(View.GONE);
        }
        tv_glassType.setText(drink.getStrGlass());
        tv_instructions.setText(drink.getStrInstructions());
        ArrayList<String> ingredientArray = new ArrayList<>(Arrays.asList(
                drink.getStrIngredient1(), drink.getStrIngredient2(), drink.getStrIngredient3(),
                drink.getStrIngredient4(), drink.getStrIngredient5(), drink.getStrIngredient6(),
                drink.getStrIngredient7(), drink.getStrIngredient8(), drink.getStrIngredient9(),
                drink.getStrIngredient10(), drink.getStrIngredient11(), drink.getStrIngredient12(),
                drink.getStrIngredient13(), drink.getStrIngredient14(), drink.getStrIngredient15()));
        ArrayList<String> measureArray = new ArrayList<>(Arrays.asList(
                drink.getStrMeasure1(), drink.getStrMeasure2(), drink.getStrMeasure3(),
                drink.getStrMeasure4(), drink.getStrMeasure5(), drink.getStrMeasure6(),
                drink.getStrMeasure7(), drink.getStrMeasure8(), drink.getStrMeasure9(),
                drink.getStrMeasure10(), drink.getStrMeasure11(), drink.getStrMeasure12(),
                drink.getStrMeasure13(), drink.getStrMeasure14(), drink.getStrMeasure15()));
        for (int i = 0; i < ingredientViewArrayList.size(); i++) {
            TextView textView = (TextView) ingredientViewArrayList.get(i);
            if (ingredientArray.get(i) != null) {
                String ingredientText;
                if (measureArray.get(i) != null) {
                    ingredientText = measureArray.get(i) + " " + ingredientArray.get(i);
                } else {
                    ingredientText = ingredientArray.get(i);
                }
                textView = (TextView) ingredientViewArrayList.get(i);
                textView.setText(ingredientText);
                textView.setVisibility(View.VISIBLE);
            } else {
                textView.setVisibility(View.GONE);

            }
        }
    }

    @Override
    public void onFailure(Call<Drinks> call, Throwable t) {
        t.printStackTrace();
        Log.d("COCKTAIL_INFO", "Error getting cocktails");
    }


    public List<Drink> getCocktails() {
        if (drinkList != null) {
            Log.d("COCKTAIL_Count", " Cocktail Count--" + drinks.drinks.size());
        }
        else {
            Log.d("COCKTAIL_Count", " Cocktails object is null");
        }
        return drinkList;
    }

    public Drink getDrink() {
        if (drink != null) {
            Log.d("DRINK_INFOt",  drink.toString());
        }
        else {
            Log.d("COCKTAIL_Count", " Drink object is null");
        }
        return drink;
    }
}
