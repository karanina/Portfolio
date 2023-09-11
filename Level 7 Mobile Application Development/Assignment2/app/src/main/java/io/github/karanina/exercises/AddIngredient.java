package io.github.karanina.exercises;

import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.os.Bundle;

import android.text.TextUtils;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import com.google.firebase.database.DatabaseReference;

import java.util.Calendar;

import io.github.karanina.exercises.model.Ingredient;


public class AddIngredient extends AppCompatActivity implements View.OnClickListener {

    DatabaseReference databaseReference;
    TextView et_ingredientName, tv_datePurchased, et_volume, et_quantity, et_likedBy;
    Button btn_addIngredient, btn_datePurchased;
    ImageView btn_goBack;
    IngredientDAO ingredientDAO;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_add_ingredient);

        ingredientDAO = new IngredientDAO();


        et_ingredientName = findViewById(R.id.ingredientName);
        tv_datePurchased = findViewById(R.id.datePurchased);
        et_volume = findViewById(R.id.volume);
        et_quantity = findViewById(R.id.quantity);
        et_likedBy = findViewById(R.id.likedBy);
        btn_addIngredient = findViewById(R.id.btn_addIngredient);
        btn_datePurchased = findViewById(R.id.btn_datePurchased);
        btn_goBack = findViewById(R.id.btn_goBack);

        btn_addIngredient.setOnClickListener(this);
        btn_goBack.setOnClickListener(this);
        btn_datePurchased.setOnClickListener(this);
    }

    @Override
    public void onClick(View view) {
        if (view.getId() == btn_datePurchased.getId()){
            datePickerDialog();
        }
        else if (view.getId() == btn_addIngredient.getId()){
            Ingredient ingredient = new Ingredient(et_ingredientName.getText().toString(),
                    tv_datePurchased.getText().toString(),
                    et_volume.getText().toString(),
                    et_quantity.getText().toString(),
                    et_likedBy.getText().toString());

            if (TextUtils.isEmpty(et_ingredientName.toString()) && (TextUtils.isEmpty(et_quantity.toString())))
            {
                Toast.makeText(AddIngredient.this, "Please add an ingredient name and quantity", Toast.LENGTH_SHORT).show();
            }
            else
            {
                ingredientDAO.add(ingredient).addOnSuccessListener(success -> {
                    Toast.makeText(this, "Ingredient added.",
                            Toast.LENGTH_LONG).show();
                    finish();
                }).addOnFailureListener(fail -> {
                    Toast.makeText(this,
                            fail.getMessage(), Toast.LENGTH_LONG).show();
                });
            }
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
                String date = dayOfMonth + "-" + (month + 1) + "-" + year;
                        tv_datePurchased.setText(date);

                }
        }, currentYear, currentMonth, currentDay);
        datePickerDialog.show();
    }
}
