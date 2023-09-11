package io.github.karanina.exercises;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.ValueEventListener;

import java.io.Serializable;
import java.util.ArrayList;
import java.util.Locale;

import io.github.karanina.exercises.model.Ingredient;

public class ListIngredientsRVAdapter extends RecyclerView.Adapter<ListIngredientsRVHolder> {

    ArrayList<Ingredient> ingredientList = new ArrayList<>();
    Context context;
    IngredientDAO ingredientDAO;
    Ingredient ingredient;

    public ListIngredientsRVAdapter(Context context, ArrayList<Ingredient> ingredients) {
        this.context = context;
        this.ingredientList = ingredients;
    }

    public void setItems(ArrayList<Ingredient> ingredients) {
        this.ingredientList = ingredients;
        notifyDataSetChanged();
    }

    String key;

    @NonNull
    @Override
    public ListIngredientsRVHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        // Inflates the layout (Giving the look to the rows)
        LayoutInflater layoutInflater = LayoutInflater.from(context);
        View view = layoutInflater.inflate(R.layout.activity_list_ingredients_row, parent, false);
        return new ListIngredientsRVHolder(view);
    }

    @Override
    public void onBindViewHolder(@NonNull ListIngredientsRVHolder holder, int position) {
        Ingredient ingredient = ingredientList.get(position);
        holder.db_ingredientName.setText(ingredient.getName());
        holder.db_volume.setText(ingredient.getVolume());
        holder.db_quantity.setText(ingredient.getQuantity());
        holder.db_datePurchased.setText(ingredient.getDatePurchased());
        holder.db_likedBy.setText(ingredient.getLikedBy());
        holder.btn_updateIngredient.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Intent intent = new Intent(context, UpdateIngredient.class);
                String key = ingredient.getKey();
                intent.putExtra("Update", key);
                context.startActivity(intent);

            }
        });
        holder.btn_deleteIngredient.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                AlertDialog.Builder dialogBuilder = new AlertDialog.Builder(context);
                dialogBuilder.setTitle("Delete Ingredient?");
                dialogBuilder.setMessage(String.format("Are you sure you want to delete %s?", ingredient.getName()));
                dialogBuilder.setPositiveButton("Yes", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        Toast.makeText(context, String.format("%s has been deleted.", ingredient.getName()), Toast.LENGTH_SHORT).show();
                        ingredientList.remove(ingredient);
                        notifyItemRemoved(holder.getAdapterPosition());
                        ingredientDAO = new IngredientDAO();
                        ingredientDAO.delete(ingredient.getKey()).addOnSuccessListener(success -> {
                            Toast.makeText(context,
                                    String.format("%s has been deleted.", ingredient.getName()), Toast.LENGTH_SHORT).show();
                            setItems(ingredientList);
                        }).addOnFailureListener(fail -> {
                            Toast.makeText(context,
                                    fail.getMessage(), Toast.LENGTH_SHORT).show();
                        });
                        ;
                    }
                });
                dialogBuilder.setNegativeButton("Cancel", new DialogInterface.OnClickListener() {
                    @Override
                    public void onClick(DialogInterface dialog, int which) {
                        dialog.cancel();
                    }
                });
                AlertDialog alertDialog = dialogBuilder.create();
                alertDialog.show();
            }
        });
    }

    @Override
    public int getItemCount() {
        return ingredientList.size();
    }
}
