package io.github.karanina.exercises;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.ValueEventListener;
import com.squareup.picasso.Picasso;

import java.util.ArrayList;
import java.util.Arrays;

import io.github.karanina.exercises.model.Drink;
import io.github.karanina.exercises.model.Favourite;
import io.github.karanina.exercises.rest.CocktailControllerRESTAPI;

public class CocktailRecipe extends AppCompatActivity implements View.OnClickListener {

    TextView tv_cocktailRecipe, tv_cocktailAKA, tv_glassType, tv_instructions,
            tv_ingredient1, tv_ingredient2, tv_ingredient3, tv_ingredient4, tv_ingredient5,
            tv_ingredient6, tv_ingredient7, tv_ingredient8, tv_ingredient9, tv_ingredient10,
            tv_ingredient11, tv_ingredient12, tv_ingredient13, tv_ingredient14, tv_ingredient15;
    ImageView img_cocktail, btn_goBack;
    int drinkID;
    Button btn_addToFavourites, btn_removeFromFavourites;
    Drink cocktail;

    FavouriteDAO favouriteDAO;
    String favouriteKey;
    Favourite favourite;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_cocktail_recipe);

        // Get access to the views.
        tv_cocktailRecipe = findViewById(R.id.tv_cocktailRecipe);
        img_cocktail = findViewById(R.id.img_cocktail);
        tv_cocktailAKA = findViewById(R.id.tv_cocktailAKA);
        tv_glassType = findViewById(R.id.tv_glassType);
        tv_instructions = findViewById(R.id.tv_instructions);
        tv_ingredient1 = findViewById(R.id.tv_ingredient1);
        tv_ingredient2 = findViewById(R.id.tv_ingredient2);
        tv_ingredient3 = findViewById(R.id.tv_ingredient3);
        tv_ingredient4 = findViewById(R.id.tv_ingredient4);
        tv_ingredient5 = findViewById(R.id.tv_ingredient5);
        tv_ingredient6 = findViewById(R.id.tv_ingredient6);
        tv_ingredient7 = findViewById(R.id.tv_ingredient7);
        tv_ingredient8 = findViewById(R.id.tv_ingredient8);
        tv_ingredient9 = findViewById(R.id.tv_ingredient9);
        tv_ingredient10 = findViewById(R.id.tv_ingredient10);
        tv_ingredient11 = findViewById(R.id.tv_ingredient11);
        tv_ingredient12 = findViewById(R.id.tv_ingredient12);
        tv_ingredient13 = findViewById(R.id.tv_ingredient13);
        tv_ingredient14 = findViewById(R.id.tv_ingredient14);
        tv_ingredient15 = findViewById(R.id.tv_ingredient15);
        btn_goBack = findViewById(R.id.btn_goBack);
        btn_addToFavourites = findViewById(R.id.btn_addToFavourites);
        btn_removeFromFavourites = findViewById(R.id.btn_removeFromFavourites);

        // get drinkID
        Intent intent = getIntent();
        drinkID = intent.getIntExtra("drinkID", 0);

        // contact firebase to see if the drink is on the favourites list.
        contactDB();

        // set the onclick listeners if depending on if the drink is a favourite or not.
        // If not, contact the API to get the details.
        if (favourite != null) {
            btn_removeFromFavourites.setOnClickListener(this);
        } else {
            btn_addToFavourites.setOnClickListener(this);
            contactAPI();
        }

        // set the goBack event listener
        btn_goBack.setOnClickListener(this);
    }

    // Contact firebase to
    private void contactDB() {
        favouriteDAO = new FavouriteDAO();
        favouriteDAO.get().addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                for (DataSnapshot data : snapshot.getChildren()) {
                    favourite = data.getValue(Favourite.class);
                    if (favourite.getIdDrink() == drinkID) {
                        setCocktailInfo(favourite);
                        btn_removeFromFavourites.setVisibility(View.VISIBLE);
                        btn_addToFavourites.setVisibility(View.GONE);
                        break;
                    }
                }
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });
    }

    private void contactAPI() {
        CocktailControllerRESTAPI cocktailControllerRESTAPI = new CocktailControllerRESTAPI();
        cocktailControllerRESTAPI.start(getApplicationContext(), drinkID, createIngredientViewArray(),
                tv_cocktailRecipe, tv_cocktailAKA, tv_glassType, tv_instructions, img_cocktail);
        cocktail = cocktailControllerRESTAPI.getDrink();
        setCocktailInfo(cocktail);

    }


    private void setCocktailInfo(Drink drink) {
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
        ArrayList<View> ingredientViewArray = createIngredientViewArray();

        for (int i = 0; i < ingredientViewArray.size(); i++) {
            TextView textView = (TextView) ingredientViewArray.get(i);
            if (ingredientArray.get(i) != null) {
                String ingredientText;
                if (measureArray.get(i) != null) {
                    ingredientText = measureArray.get(i) + " " + ingredientArray.get(i);
                } else {
                    ingredientText = ingredientArray.get(i);
                }
                textView = (TextView) ingredientViewArray.get(i);
                textView.setText(ingredientText);
                textView.setVisibility(View.VISIBLE);
            } else {
                textView.setVisibility(View.GONE);

            }
        }

    }

    @Override
    public void onClick(View view) {
        if (view.getId() == btn_goBack.getId()) {
            finish();
        } else if (view.getId() == btn_addToFavourites.getId()) {
            favourite = new Favourite(cocktail);
            favouriteDAO.add(favourite).addOnSuccessListener(success -> {
                Toast.makeText(this, cocktail.getStrDrink() + " added to your favourites list", Toast.LENGTH_SHORT).show();
                Log.d("FAVOURITE_SUCCESS", cocktail.getStrDrink() + " added to your favourites list.");
                btn_addToFavourites.setVisibility(View.GONE);
                btn_removeFromFavourites.setVisibility(View.VISIBLE);
            }).addOnFailureListener(fail -> {
                Toast.makeText(this, cocktail.getStrDrink() + " was not added to your favourites list", Toast.LENGTH_SHORT).show();
                Log.d("FAVOURITE_FAILURE", cocktail.getStrDrink() + " was not be added to your favourites list.");
            });
        } else if (view.getId() == btn_removeFromFavourites.getId()) {
            favouriteDAO.remove(favourite.getKey()).addOnSuccessListener(success -> {
                Toast.makeText(this,
                        cocktail.getStrDrink() + " has been removed from your favourites list.",
                        Toast.LENGTH_SHORT).show();
                btn_addToFavourites.setVisibility(View.VISIBLE);
                btn_removeFromFavourites.setVisibility(View.GONE);
            }).addOnFailureListener(fail -> {
                Toast.makeText(this,
                        fail.getMessage(), Toast.LENGTH_SHORT).show();
            });

        }
    }



    public ArrayList<View> createIngredientViewArray() {
        ArrayList<View> viewArray = new ArrayList<>(Arrays.asList(
                tv_ingredient1, tv_ingredient2, tv_ingredient3, tv_ingredient4,
                tv_ingredient5, tv_ingredient6, tv_ingredient7, tv_ingredient8,
                tv_ingredient9, tv_ingredient10, tv_ingredient11, tv_ingredient12,
                tv_ingredient13, tv_ingredient14, tv_ingredient15));
        return viewArray;
    }
}
