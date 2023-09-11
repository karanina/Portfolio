package io.github.karanina.exercises;

import androidx.annotation.NonNull;
import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.database.DataSnapshot;
import com.google.firebase.database.DatabaseError;
import com.google.firebase.database.DatabaseReference;
import com.google.firebase.database.FirebaseDatabase;
import com.google.firebase.database.ValueEventListener;

import java.util.ArrayList;
import java.util.Calendar;
import java.util.HashMap;

import io.github.karanina.exercises.model.Ingredient;

public class UpdateIngredient extends AppCompatActivity implements View.OnClickListener {

    TextView et_ingredientName, tv_datePurchased, et_volume, et_quantity, et_likedBy;
    Button btn_updateIngredient, btn_changeDatePurchased;
    String datePurchased;
    ImageView btn_goBack;
    IngredientDAO ingredientDAO;
    Ingredient ingredient;
    String ingredientKey;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_update_ingredient);

        et_ingredientName = findViewById(R.id.db_ingredientName);
        tv_datePurchased = findViewById(R.id.db_datePurchased);
        et_volume = findViewById(R.id.db_volume);
        et_quantity = findViewById(R.id.db_quantity);
        et_likedBy = findViewById(R.id.db_likedBy);
        btn_changeDatePurchased = findViewById(R.id.btn_changeDatePurchased);
        btn_updateIngredient = findViewById(R.id.btn_updateIngredient);
        btn_goBack = findViewById(R.id.btn_goBack);

        ingredientKey = getIntent().getStringExtra("Update");
        ingredientDAO = new IngredientDAO();
        ingredientDAO.get(ingredientKey).addListenerForSingleValueEvent(new ValueEventListener() {
            @Override
            public void onDataChange(@NonNull DataSnapshot snapshot) {
                ingredient = snapshot.getValue(Ingredient.class);
                et_ingredientName.setText(ingredient.getName());
                tv_datePurchased.setText(ingredient.getDatePurchased());
                et_volume.setText(ingredient.getVolume());
                et_quantity.setText(ingredient.getQuantity());
                et_likedBy.setText(ingredient.getLikedBy());
            }

            @Override
            public void onCancelled(@NonNull DatabaseError error) {

            }
        });

        btn_changeDatePurchased.setOnClickListener(this);
        btn_updateIngredient.setOnClickListener(this);
        btn_goBack.setOnClickListener(this);

    }

    @Override
    public void onClick(View view) {
        if (view.getId() == btn_changeDatePurchased.getId()){
            datePickerDialog();
        }
        else if (view.getId() == btn_updateIngredient.getId()) {
            HashMap<String, Object> hashMap = new HashMap<>();
            hashMap.put("name", et_ingredientName.getText().toString());
            hashMap.put("datePurchased", datePurchased);
            hashMap.put("volume", et_volume.getText().toString());
            hashMap.put("quantity", et_quantity.getText().toString());
            hashMap.put("likedBy", et_likedBy.getText().toString());
            ingredientDAO.update(ingredientKey, hashMap).addOnSuccessListener(success -> {
                Toast.makeText(this,
                        et_ingredientName.getText().toString() + " updated.",
                        Toast.LENGTH_SHORT).show();
                Intent intent = new Intent(this, ListIngredients.class);
                startActivity(intent);
            }).addOnFailureListener(fail -> {Toast.makeText(this,
                    fail.getMessage(), Toast.LENGTH_SHORT).show();
            });;
        }
        else if (view.getId() == btn_goBack.getId()){
            finish();
        }
    }

    private void datePickerDialog() {
        // Get current date
        final Calendar currentDate = Calendar.getInstance();
        int currentYear = currentDate.get(Calendar.YEAR);
        int currentMonth = currentDate.get(Calendar.MONTH);
        int currentDay = currentDate.get(Calendar.DAY_OF_MONTH);
        DatePickerDialog datePickerDialog = new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
                datePurchased = dayOfMonth + "-" + (month + 1) + "-" + year;
                tv_datePurchased.setText(datePurchased);

            }
        }, currentYear, currentMonth, currentDay);
        datePickerDialog.show();

    }
}