package io.github.karanina.exercises;

import android.content.Context;
import android.content.Intent;
import android.os.Parcelable;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.squareup.picasso.Picasso;

import java.io.Serializable;
import java.util.ArrayList;

import io.github.karanina.exercises.model.Drink;
import io.github.karanina.exercises.model.Favourite;

public class FavouriteCocktailsRVAdapter extends RecyclerView.Adapter<FavouriteCocktailsRVHolder> {

    ArrayList<Favourite> drinkList;
    Context context;


    public FavouriteCocktailsRVAdapter(Context context) {

        this.context = context;
    }

    @NonNull
    @Override
    public FavouriteCocktailsRVHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        // Inflates the layout (Giving the look to the rows)
        LayoutInflater layoutInflater = LayoutInflater.from(context);
        View view = layoutInflater.inflate(R.layout.activity_favourite_cocktails_row, parent, false);
        return new FavouriteCocktailsRVHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull FavouriteCocktailsRVHolder holder, int position) {
        Favourite favourite = drinkList.get(position);
        holder.db_cocktailName.setText(favourite.getStrDrink());
        Picasso.get().load(favourite.getStrDrinkThumb()).into(holder.img_cocktail);
        holder.btn_viewRecipe.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(context, CocktailRecipe.class);
                intent.putExtra("drinkID", favourite.getIdDrink());
                context.startActivity(intent);
            }
        });

    }


    @Override
    public int getItemCount() {
        if (drinkList != null) {
            return drinkList.size();
        } else {
            return 0;
        }
    }


    public void setItems(ArrayList<Favourite> drinks) {
        this.drinkList = drinks;
        notifyDataSetChanged();
    }
}
