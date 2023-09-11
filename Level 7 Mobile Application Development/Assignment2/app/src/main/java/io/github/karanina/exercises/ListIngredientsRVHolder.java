package io.github.karanina.exercises;

import android.content.Intent;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.TextView;

import androidx.activity.result.contract.ActivityResultContracts;
import androidx.annotation.NonNull;
import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

public class ListIngredientsRVHolder extends RecyclerView.ViewHolder {

    CardView cv_listIngredientsRow;
    TextView db_ingredientName, db_volume, db_quantity, db_datePurchased, db_likedBy;
    Button btn_updateIngredient, btn_deleteIngredient;


    public ListIngredientsRVHolder(@NonNull View itemView) {
        super(itemView);

        cv_listIngredientsRow = itemView.findViewById(R.id.cv_listIngredients);
        db_ingredientName = itemView.findViewById(R.id.db_ingredientName);
        db_volume = itemView.findViewById(R.id.db_volume);
        db_quantity = itemView.findViewById(R.id.db_quantity);
        db_datePurchased = itemView.findViewById(R.id.db_datePurchased);
        db_likedBy = itemView.findViewById(R.id.db_likedBy);
        btn_updateIngredient = itemView.findViewById(R.id.btn_updateIngredient);
        btn_deleteIngredient = itemView.findViewById(R.id.btn_deleteIngredient);
    }
}
