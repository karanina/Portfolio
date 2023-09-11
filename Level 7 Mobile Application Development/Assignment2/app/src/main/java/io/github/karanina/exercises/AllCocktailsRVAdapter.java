package io.github.karanina.exercises;

import android.content.Context;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.squareup.picasso.Picasso;

import java.util.ArrayList;
import java.util.List;

import io.github.karanina.exercises.model.Drink;
import io.github.karanina.exercises.model.Drinks;

public class AllCocktailsRVAdapter extends RecyclerView.Adapter<AllCocktailsRVHolder> {

    ArrayList<Drink> drinkList;
    Context context;

    public AllCocktailsRVAdapter(Context context) {

        this.context = context;
    }

    public Context getContext() {
        return context;
    }

    public void setItems(ArrayList<Drink> drinks) {
       this.drinkList = drinks;
       notifyDataSetChanged();
    }

    @NonNull
    @Override
    public AllCocktailsRVHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        // Inflates the layout (Giving the look to the rows)
        LayoutInflater layoutInflater = LayoutInflater.from(context);
        View view = layoutInflater.inflate(R.layout.activity_all_cocktails_row, parent, false);
        return new AllCocktailsRVHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull AllCocktailsRVHolder holder, int position) {
        Drink drink = drinkList.get(position);
        String cocktailName = drink.getStrDrink();
        holder.db_cocktailName.setText(cocktailName);
        Picasso.get().load(drink.getStrDrinkThumb()).into(holder.img_cocktail);
        holder.btn_viewRecipe.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(context, CocktailRecipe.class);
                intent.putExtra("drinkID", drink.getIdDrink() );
                intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                context.startActivity(intent);
            }
        });

    }

    @Override
    public int getItemCount() {
if (drinkList != null) {
    return drinkList.size();
}
else {
    return 0;
}
    }
}

