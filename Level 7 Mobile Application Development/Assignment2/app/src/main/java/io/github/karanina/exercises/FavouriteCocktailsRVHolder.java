package io.github.karanina.exercises;

import android.view.View;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

public class FavouriteCocktailsRVHolder extends RecyclerView.ViewHolder {
    CardView cv_favouriteCocktails;
    TextView db_cocktailName;
    ImageView img_cocktail;
    Button btn_viewRecipe;


    public FavouriteCocktailsRVHolder(@NonNull View itemView) {
        super(itemView);

        cv_favouriteCocktails = itemView.findViewById(R.id.cv_favouriteCocktails);
        db_cocktailName = itemView.findViewById(R.id.db_cocktailName);
        img_cocktail = itemView.findViewById(R.id.img_cocktail);
        btn_viewRecipe = itemView.findViewById(R.id.btn_viewRecipe);
    }
}
